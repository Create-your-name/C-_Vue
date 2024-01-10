<template>
    <el-form :model="form" label-width="110px" :rules="rules">
        <el-tabs type="card" class="demo-tabs">
            <el-tab-pane label="FabIndex" name="second" class="UserTable">
                <el-tabs type="card" class="demo-tabs">
                    <div class="form-container">
                        <el-row class="row-bg" justify="space-between">
                            <el-col :span="6">
                                <el-form-item prop="FabIndexDate.DailyMOVE">
                                    <span class="custom-label">FabIndex.DailyMOVE</span>
                                    <el-input-number v-model="FabIndexDate.DailyMOVE" :min="1" :max="10000000" />
                                </el-form-item>
                            </el-col>
                            <el-col :span="6">
                                <el-form-item prop="FabIndexDate.PhotoOut">
                                    <span class="custom-label">FabIndex.PhotoOut</span>
                                    <el-input-number v-model="FabIndexDate.PhotoOut" :min="1" :max="10000000" />
                                </el-form-item>
                            </el-col>
                            <el-col :span="6">
                                <el-form-item prop="FabIndexDate.OutPut">
                                    <span class="custom-label">FabIndex.OutPut</span>
                                    <el-input-number v-model="FabIndexDate.OutPut" :min="1" :max="10000000" />
                                </el-form-item>
                            </el-col>
                            <el-col :span="6">
                                <el-form-item prop="FabIndexDate.WaferStart">
                                    <span class="custom-label">FabIndex.WaferStart</span>
                                    <el-input-number v-model="FabIndexDate.WaferStart" :min="1" :max="10000000" />
                                </el-form-item>
                            </el-col>
                        </el-row>
                        <el-button type="primary" @click="FabIndex()">FabIndex数据提交</el-button>
                    </div>
                </el-tabs>
            </el-tab-pane>

            <el-tab-pane label="邮件推送 数据维护(单个新增)" name="first" class="UserTable">
                <div class="form-container">

                    <el-row class="row-bg" justify="space-between">
                        <el-col :span="6">
                            <el-form-item class="Producess" prop="EmailWaferOut.GYDL">
                                <span class="producess-label">工艺大类</span>
                                <el-select v-model="EmailWaferOut.GYDL" clearable class="filter-item" placeholder="输入您对应的工艺大类">
                                                                        <el-option v-for="item in uniqueKey(tableData,'process')" :key="item.process" :label="item.process"
                                               :value="item.process" />
                                </el-select>
                            </el-form-item>
                        </el-col>
                        <el-col :span="6">
                            <el-form-item label="产品大类"  prop="Product">
                                <el-input  v-model="EmailWaferOut.Product" style="width:200px" />
                            </el-form-item>
                        </el-col>
                    </el-row>
                    <el-row class="row-bg" justify="space-between">

                        <el-col :span="6">
                            <el-form-item prop="EmailWaferOut.Stage">
                                <span class="producess-label">Stage光刻层数</span>
                                <el-input-number v-model="EmailWaferOut.Stage" :min="0" :max="10000000" />
                            </el-form-item>
                        </el-col>
                        <el-col :span="6">
                            <el-form-item prop="EmailWaferOut.BP_PCS">
                                <span class="producess-label">BP_PCS</span>
                                <el-input-number v-model="EmailWaferOut.BP_PCS" :min="0" :max="10000000" />
                            </el-form-item>
                        </el-col>
                        <el-col :span="6">
                            <el-form-item prop="EmailWaferOut.BP_Plan">
                                <span class="producess-label">BP_Plan</span>
                                <el-input-number v-model="EmailWaferOut.BP_Plan" :min="0" :max="10000000" />
                            </el-form-item>
                        </el-col>
                        <el-col :span="6">
                            <el-form-item prop="EmailWaferOut.MF_PCS">
                                <span class="producess-label">MF_PCS</span>
                                <el-input-number v-model="EmailWaferOut.MF_PCS" :min="0" :max="10000000" />
                            </el-form-item>
                        </el-col>
                    </el-row>
                    <el-row class="row-bg" justify="space-between">
                        <el-col :span="6">
                            <el-form-item prop="EmailWaferOut.MF_PLAN">
                                <span class="producess-label">MF投料目标MF_PLAN</span>
                                <el-input-number v-model="EmailWaferOut.MF_PLAN" :min="0" :max="10000000" />
                            </el-form-item>
                        </el-col>
                    </el-row>

                    <el-button type="primary" @click="EmailInsertDB()">宋星星推送邮件WaferOut数据提交</el-button>
                </div>
                 <div class="form-container">

                    <el-row class="row-bg" justify="space-between">

                        <el-col :span="6">
                            <el-form-item class="Producess" prop="lt.gydl">
                                <span class="producess-label">产品</span>
                                <el-select v-model="lt.gydl" clearable class="filter-item" placeholder="输入您对应的产品">
                                    <el-option v-for="item in uniqueKey(tableData,'product')" :key="item.product" :label="item.product"
                                               :value="item.product" />
                                               
                                </el-select>
                            </el-form-item>
                             <el-form-item class="producess-label" label="产品大类" prop="lt.gydl">
                                <el-input v-model="lt.gydl" style="width:200px" />
                            </el-form-item>
                        </el-col>

                        <el-col :span="6">
                            <el-form-item label="产品产能" prop="Cap">
                                <el-input v-model="lt.Cap" style="width:200px" />
                            </el-form-item>
                        </el-col>
                        
                    </el-row>

                    <el-button type="primary" @click="LT()">刘涛推送邮件WaferOut数据提交</el-button>
                </div>
            </el-tab-pane>
            <el-tab-pane label="SPLLOT(单个新增)" name="SPLLOT" class="UserTable">
                <el-tabs type="card" class="demo-tabs">
                    <div class="form-container">
                        <el-row class="row-bg" justify="space-between">
                            <el-col :span="6">
                                <el-form-item label="LOTID" prop="SPLLOTDATE.LOTID">
                                    <el-input v-model="SPLLOTDATE.LOTID" style="width:200px" />
                                </el-form-item>
                            </el-col>
                            <el-col :span="6">
                                <el-form-item label="部門" prop="SPLLOTDATE.DEPARTMENT">
                                    <el-input v-model="SPLLOTDATE.DEPARTMENT" style="width:200px" />
                                </el-form-item>
                            </el-col>
                            <el-col :span="6">
                                <el-form-item label="产出时间" prop="SPLLOTDATE.DOTIME">
                                    <el-input v-model="SPLLOTDATE.DOTIME" style="width:200px" />
                                </el-form-item>
                            </el-col>
                            <el-col :span="6">
                                <el-form-item label="描述" prop="SPLLOTDATE.USERDESC">
                                    <el-input v-model="SPLLOTDATE.USERDESC" style="width:200px" />
                                </el-form-item>
                            </el-col>
                        </el-row>
                        <el-button type="primary" @click="SPLLOT()">SPLLOT数据提交</el-button>
                    </div>
                </el-tabs>
            </el-tab-pane>
            <el-tab-pane label="Fab Index_Move" name="Fab Move" class="UserTable">
            </el-tab-pane>
        </el-tabs>
    </el-form>
</template>

<script>
    
    import axios from "axios";     

    export default {
        data() {
            return {
                tableData: [],
                UserInput: "",
                FabIndexDate: {
                    DailyMOVE: 0,
                    PhotoOut: 0,
                    OutPut: 0,
                    WaferStart: 0,
                },
                EmailWaferOut: {
                    GYDL: "",
                    Product: "",
                    Stage: 0,
                    BP_PCS: 0,
                    BP_Plan: 0,
                    MF_PCS: 0,
                    MF_PLAN: 0,
                },
                SPLLOTDATE: {
                    LOTID: "",
                    DEPARTMENT: "",
                    DOTIME: "",
                    USERDESC: "",
                },
                options: [ // 下拉框的选项数据
                    { label: '牛顿', value: '牛顿' },
                    { label: '高斯', value: '高斯' },
                    { label: 'MEI', value: 'MEI' },
                ],
               lt:{
               gydl:"",
               Cap:0,
               }
            };
        },
        methods: {
            FabIndex() {
                const confirmInput = prompt('请输入密码');
                if (confirmInput === 'sxx') {
                        axios.post("http://10.163.76.23/api/api/PcMonth/FabIndex", this.FabIndexDate)
                   // axios.post("https://localhost:7155/api/PcMonth/FabIndex", this.FabIndexDate)
                        .then((res) => {
                            this.formData = res.data;
                            this.total = res.data.length;
                        })
                } else {
                    alert('输入错误，请重新操作');
                }
            },
             SPLLOT() {
                const confirmInput = prompt('请输入密码');
                    if (confirmInput === 'sxx') {
                    axios.post("http://10.163.76.23/api/api/PcMonth/SPLLOT", this.SPLLOTDATE)
                   //   axios.post("https://localhost:7155/api/PcMonth/SPLLOT", this.SPLLOTDATE)
                            .then((res) => {
                                this.formData = res.data;
                                this.total = res.data.length;
                            })
                    } else {
                        alert('输入错误，请重新操作');
                    }
            },
            LT() {
                const confirmInput = prompt('请输入密码');
                if (confirmInput === 'lt') {
                        axios.post("http://10.163.76.23/api/api/PcMonth/LT", this.lt)
                    //    axios.post("https://localhost:7155/api/PcMonth/LT", this.lt)
                        .then((res) => {
                            this.formData = res.data;
                            this.total = res.data.length;
                        })
                } else {
                    alert('输入错误，请重新操作');
                }
            },
            uniqueKey(array, key) {
                return array.reduce((result, item) => {
                    if (!result.find(e => e[key] === item[key]) && item[key] != null) {
                        result.push(item);
                    }
                    return result;
                }, []);
            },
            EmailInsertDB() {
                const confirmInput = prompt('请输入密码');
                if (confirmInput === 'sxx') {
                        axios.post("http://10.163.76.23/api/api/PcMonth/WaferStart", this.EmailWaferOut)
                    //  axios.post("https://localhost:7155/api/PcMonth/WaferStart", this.EmailWaferOut)
                        .then((res) => {
                            this.formData = res.data;
                            this.total = res.data.length;
                        })
                } else {
                    alert('输入错误，请重新操作');
                }
            },
            ProductList() {
            axios
                      .get("http://10.163.76.23/api/api/PcMonth/Product")
                //  .get("https://localhost:7155/api/PcMonth/Product")
                .then((res) => {
                    this.tableData = res.data;
                })
        },
        },

    mounted() {
    this.ProductList();
        document.title = "月数据录取"
    },
    
    };
</script>

<style>
    .custom-label {
        font-size: 20px;
        margin-left: 20px;
    }

    .form-container {
        margin-left: 20px;
        margin-right: 100px;
        margin-bottom: 20px;
    }

    .row-bg {
        background-color: #f6f6f6;
        padding: 10px;
    }

    .producess-label {
        font-size: 30px;
    }

    .ml-2 {
        font-size: 35px;
        margin-left: 10px;
    }
</style>