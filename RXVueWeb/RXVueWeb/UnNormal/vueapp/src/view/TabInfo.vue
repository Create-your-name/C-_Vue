﻿<template>

    <el-form :model="form" label-width="120px" :rules="rules">
        <el-tabs type="card" class="demo-tabs">
            <el-row>
                <el-col :span="12">
                    <el-form-item label="异常单填写日期" required style="width:800px">
                        <el-row>
                            <el-col :span="11">
                                <el-form-item prop="activityBeginTime">
                                    <el-date-picker type="datetime" placeholder="开始时间" v-model="form.activityBeginTime" style="width: 150%;"
                                                    :editable="false" value-format="YYYY-MM-DD HH:mm:ss"></el-date-picker>
                                </el-form-item>
                            </el-col>
                            <el-col :span="2" style="text-align: center;">至</el-col>
                            <el-col :span="11">
                                <el-form-item prop="activityEndTime">
                                    <el-date-picker type="datetime" placeholder="结束时间" v-model="form.activityEndTime" style="width: 150%;"
                                                    :editable="false" value-format="YYYY-MM-DD HH:mm:ss"></el-date-picker>
                                </el-form-item>
                            </el-col>
                        </el-row>
                    </el-form-item>
                </el-col>
                <el-col :span="12">
                    <el-form-item label="异常单完成日期" required style="width:800px">
                        <el-row>
                            <el-col :span="11">
                                <el-form-item prop="activityBeginTime2">
                                    <el-date-picker type="datetime" placeholder="开始时间" v-model="form.activityBeginTime2" style="width: 150%;"
                                                    :editable="false" value-format="YYYY-MM-DD HH:mm:ss"></el-date-picker>
                                </el-form-item>
                            </el-col>
                            <el-col :span="2" style="text-align: center;">至</el-col>
                            <el-col :span="11">
                                <el-form-item prop="activityEndTime2">
                                    <el-date-picker type="datetime" placeholder="结束时间" v-model="form.activityEndTime2" style="width: 150%;"
                                                    :editable="false" value-format="YYYY-MM-DD HH:mm:ss"></el-date-picker>
                                </el-form-item>
                            </el-col>
                        </el-row>
                    </el-form-item>
                </el-col>
            </el-row>


            <el-row class="row-bg" justify="space-evenly">
                <el-col :span="12">
                    <el-form-item label="异常单号" prop="f_Yc_Odd">
                        <el-input v-model="form.f_Yc_Odd" style="width:200px" />
                        <el-select v-model="form.f_Yc_Odd" clearable class="filter-item" placeholder="输入您所需的异常单号">
                            <el-option v-for="item in uniqueKey(tableData,'no')" :key="item.no" :label="item.no" :value="item.no" />
                        </el-select>
                    </el-form-item>
                </el-col>
                <el-col :span="12">
                    <el-form-item label="批号" prop="f_LOT">
                        <el-input v-model="form.f_LOT" style="width:200px" />
                        <el-select v-model="form.f_LOT" clearable placeholder="输入您所需的批号">
                            <el-option v-for="item in uniqueKey(tableData,'ph')" :key="item.ph" :label="item.ph" :value="item.ph" />

                        </el-select>
                    </el-form-item>
                </el-col>
            </el-row>

            <el-row class="row-bg" justify="space-evenly">
                <el-col :span="4">
                    <el-form-item label="工    艺" prop="f_Pro">
                        <el-select v-model="form.f_Pro" clearable placeholder="输入您所需的工艺名称">
                            <el-option v-for="item in uniqueKey(tableData,'gy')" :key="item.gy" :label="item.gy"
                                       :value="item.gy" />

                        </el-select>
                    </el-form-item>
                </el-col>
                <el-col :span="5">
                    <el-form-item label="Equip ID" prop="f_Equip_ID">
                        <el-select v-model="form.f_Equip_ID" clearable placeholder="输入您所需的设备名称">
                            <el-option v-for="item in uniqueKey(tableData,'equipid')" :key="item.equipid" :label="item.equipid"
                                       :value="item.equipid" />
                        </el-select>
                    </el-form-item>
                </el-col>
                <el-col :span="5">
                    <el-form-item label="工程师确认部门" prop="f_OP_Depart">
                        <el-select v-model="form.f_OP_Depart" clearable placeholder="输入您所需的部门名称">
                            <el-option v-for="item in uniqueKey(tableData,'ycclBm')" :key="item.ycclBm" :label="item.ycclBm"
                                       :value="item.ycclBm" />
                        </el-select>
                    </el-form-item>
                </el-col>
                <el-col :span="5">
                    <el-form-item label="工艺大类" prop="f_Pro_Kind">
                        <el-select v-model="form.f_Pro_Kind" clearable placeholder="输入您所需的工艺大类">
                            <el-option v-for="item in uniqueKey(tableData,'gy')" :key="item.gy" :label="item.gy"
                                       :value="item.gy" />
                        </el-select>
                    </el-form-item>
                </el-col>
                <el-col :span="5">
                    <el-form-item label="责任部门一" prop="f_Res_Depart">
                        <el-select v-model="form.f_Res_Depart" clearable placeholder="输入所对应的责任部门一">
                            <el-option v-for="item in uniqueKey(tableData,'zrbm1')" :key="item.zrbm1" :label="item.zrbm1"
                                       :value="item.zrbm1" />
                        </el-select>
                    </el-form-item>
                </el-col>
            </el-row>

            <el-row class="row-bg" justify="space-evenly">
                <el-col :span="4">
                    <el-form-item label="工程师确认现象" prop="f_OP_Pheno">
                        <el-select v-model="form.f_OP_Pheno" clearable placeholder="请确认现象 ">
                            <el-option v-for="item in uniqueKey(tableData,'ycxxqr')" :key="item.ycxxqr" :label="item.ycxxqr"
                                       :value="item.ycxxqr" />
                        </el-select>
                    </el-form-item>
                </el-col>
                <el-col :span="5">
                    <el-form-item label="产品名称" prop="f_Product_name">
                        <el-select v-model="form.f_Product_name" clearable placeholder="请输入产品名称">
                            <el-option v-for="item in uniqueKey(tableData,'cppz')" :key="item.cppz" :label="item.cppz"
                                       :value="item.cppz" />
                        </el-select>
                    </el-form-item>
                </el-col>
                <el-col :span="5">
                    <el-form-item label="工程师确认层次" prop="f_OP_Level">
                        <el-select v-model="form.f_OP_Level" clearable placeholder="请确认层次">
                            <el-option v-for="item in uniqueKey(tableData,'ycclcc')" :key="item.ycclcc" :label="item.ycclcc"
                                       :value="item.ycclcc" />
                        </el-select>
                    </el-form-item>
                </el-col>
                <el-col :span="5">
                    <el-form-item label="确认意见" prop="f_Idea">
                        <el-select v-model="form.f_Idea" clearable placeholder="请输入您的意见">
                            <el-option v-for="item in uniqueKey(tableData,'cpownerQryj')" :key="item.cpownerQryj" :label="item.cpownerQryj"
                                       :value="item.cpownerQryj" />
                        </el-select>
                    </el-form-item>
                </el-col>
                <el-col :span="5">
                    <el-form-item label="责任部门二" prop="f_Res_Depart_2">
                        <el-select v-model="form.f_Res_Depart_2" clearable placeholder="请输入责任部门二">
                            <el-option v-for="item in uniqueKey(tableData,'zrbm2')" :key="item.zrbm2" :label="item.zrbm2"
                                       :value="item.zrbm2" />
                        </el-select>
                    </el-form-item>
                </el-col>
            </el-row>


            <el-row class="row-bg" justify="space-evenly">
                <el-col :span="8">
                    <el-form-item label="异常原因归类" prop="f_Cause_Range">
                        <el-select v-model="form.f_Cause_Range" clearable placeholder="请选择异常原因">
                            <el-option v-for="item in uniqueKey(tableData,'ycyygl')" :key="item.ycyygl" :label="item.ycyygl"
                                       :value="item.ycyygl" />
                        </el-select>
                    </el-form-item>
                </el-col>
                <el-col :span="8">
                    <!--   @change="getDataList()" @clear="getDataList()" @focus="get_OP_Class"-->
                    <el-form-item label="工程师确认分类" prop="f_OP_Class">
                        <el-select v-model="form.f_OP_Class" clearable placeholder="请确认分类">
                            <el-option v-for="item in uniqueKey(tableData,'ycclFl')" :key="item.ycclFl" :label="item.ycclFl"
                                       :value="item.ycclFl" />
                        </el-select>
                    </el-form-item>
                </el-col>

            </el-row>



            <el-button type="primary" @click="getDataList()"> 查询</el-button>
            <Tab :table="table" :tableLabel="tableLabel" :Tid="tableID" :total="total" @updateNum="updateNum" :headerCellStyle="headerCellStyle" :rowStyle="rowStyle" :cellStyle="cellStyle"></Tab>


        </el-tabs>


    <!--     props:['tableData'] ,         props 接收从父组件传过来的值 -->    
    </el-form>

</template>


<script >
    import axios from "axios";
    import img from '@/assets/rxlogo.jpg'
    import Tab from "./TabTest.vue"
    export default {
       components: {
            Tab,
        },
        data(){
             var validateEventEnd = (rule, value, callback) => {
                if (value < this.form.activityBeginTime) {
                    callback(new Error("结束时间需晚于开始时间!"));
                } else {
                    callback();
                    }
                };
            var validateEventEnd2 = (rule, value, callback) => {
                    if (value < this.form.activityBeginTime2) {
                        callback(new Error("结束时间需晚于开始时间!"));
                    } else {
                        callback();
                    }
                };
            return{
                tableID: 'T2',
                total:1000,      
                headerCellStyle: {
                background:'#9ACD32',height:'250',color:'#000000',border: '1px solid tan','text-align':'center',
                },
                rowStyle: {
                background: '#AFEEEE', height: 5 + 'px'
                },
                cellStyle: {
                'text-align': 'center'
                },
                form: {
                    f_Yc_Odd: "", //异常单号
                    f_LOT: "", //批号             4
                    f_Pro: "", //工艺
                    f_Equip_ID: "", //设备ID      2
                    f_OP_Depart: "", //工程师确认部门
                    f_Pro_Kind: "", //工艺大类
                    f_Res_Depart: "", //责任部门1
                    f_OP_Pheno: "", //工程师确认现象
                    f_Product_name: "", //产品名称
                    f_Res_Depart_2: "", //责任部门2
                    f_OP_Level: "", //工程师确认层次
                    f_Idea: "", //意见        3
                    f_Cause_Range: "", //异常原因归类 1
                    f_OP_Class: "", //工程师确认分类
                    f_bf_NoNull: "", //     报废非0
                    status: "",         //当前状态
                    region: "",  //排序1
                    region2: "", //排序2
                    f_ReHu: "",
                    activityBeginTime: "",   //异常单填写时间1
                    activityEndTime: "",    //异常单填写时间2

                activityBeginTime2: "",   //异常单完成时间1
                activityEndTime2: "",    //异常单完成时间2
                },
                 tableLabel: [
                { label: 'TASKID', width: '180', prop: 'no', show: true },
                { label: '责任部门一', width: '150', prop: 'zrbm1', show: true },
                { label: '报废', width: '100', prop: 'zrbm1Bf', show: true },
                { label: '返工', width: '100', prop: 'zrbm1Fg', show: true },
                { label: '异常放行', width: '100', prop: 'zrbm1Ycfx', show: true },
                { label: '正常放行', width: '100', prop: 'zrbm1Zcfx', show: true },
                { label: '原因六大类', width: '150', prop: 'zrbm1Yyldl', show: true },
                { label: '责任部门二', width: '150', prop: 'zrbm2', show: true },
                { label: '报废', width: '100', prop: 'zrbm2Bf', show: true },
                { label: '返工', width: '100', prop: 'zrbm2Fg', show: true },
                { label: '异常放行', width: '100', prop: 'zrbm2Ycfx', show: true },
                { label: '正常放行', width: '100', prop: 'zrbm2Zcfx', show: true },
                { label: '原因六大类', width: '150', prop: 'zrbm2Yyldl', show: true },
                { label: '备注', width: '150', show: true }
                    ],
                imgUrl: img,
                tableData: [],
                table:[],
                 rules: {
                    activityEndTime: [{
                        validator: validateEventEnd,
                        trigger: "change"
                    }],
                    activityEndTime2: [{
                        validator: validateEventEnd2,
                        trigger: "change"
                    }],
                }
            };
        },
        methods: {
            changeTime() {
                this.$forceUpdate()
            },
            updateNum(num) {
                this.tableLabel = num;
            },
             onRadioChange(e , i) {
                  console.log(e.target.tagName);
                  if (e.target.tagName === "INPUT") {
                    if (this.form.f_ReHu === "") {
                           this.form.f_ReHu = i;
                    } else {
                         this.form.f_ReHu = "";
                    }
                  }
                  console.log(123);
            },
            onRadioChange2(e, i) {
                console.log(e.target.tagName);
                if (e.target.tagName === "INPUT") {
                     if (this.form.f_bf_NoNull === "") {
                      this.form.f_bf_NoNull = i;
                    } else {
                       this.form.f_bf_NoNull = "";
                    }
                }
                console.log(123);
            },
         //  getDataList() {
          //      axios.post("vue-api/DepartMent/Depart/", this.form)
          //          .then((res) => {
          //              this.table= res.data;
          //          }).catch(err => {
          //              console.log(err)
           //         })
          //  },
          getDataList() {
            //    axios.post("https://localhost:7155/api/DepartMent/Lot", this.form)
                  axios.post("http://10.163.76.23/api/api/DepartMent/Lot", this.form)
                        .then((res) => {
                            this.table = res.data;
                            this.total = res.data.lineList.length;
                            console.log(this.formData)
                        }).catch(err => {
                            console.log(err)
                        })
                },
            uniqueKey(array, key) {
                return array.reduce((result, item) => {
                    if (!result.find(e => e[key] === item[key]) && item[key] != null) {
                        result.push(item);
                    }
                    return result;
                }, []);
            },
//	QueryDepartList() {
  //              axios
   //                 .get("vue-api/DepartMent/")
    //                .then((res) => {
    //                    this.tableData = res.data;
     //               })
      //      },
          QueryDepartList() {
                    axios
                  //     .get("https://localhost:7155/api/DepartMent")
                        .get("http://10.163.76.23/api/api/DepartMent")
                        .then((res) => {
                            this.tableData = res.data;
                        })
                },
            getInfoDetail() { 
                console.log(this.$route.query.Data);
                this.Data = this.$route.query.Data;
                console.log(this.Data);
            },
            clickRow(row) {
                this.$refs.filterTable.toggleRowSelection(row)
                this.$emit('clickRow', row)
            }
        },

        mounted() {
	      this.QueryDepartList();
            document.title = "异常部门查询"
        },
    }
</script>

<style lang="less">

.el-table__body .el-table__row.hover-row td{
  background-color: #FFFACD !important;
}

</style>