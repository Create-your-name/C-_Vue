 <template>
     <el-form :model="form" label-width="120px" :rules="rules">
         <el-button type="primary" @click="QueryTimeList()"> 查询</el-button>
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
                 </el-row>
             <TabTest :table="tableData" :tableLabel="tableLabel" :Tid="tableID" :total="total" @updateNum="updateNum" ></TabTest>
         </el-tabs>

     </el-form>

</template>
<script>

    import TabTest from "@/view/TabTest.vue"
    import axios from "axios";

    export default {
    components: {
        TabTest
    },
        data() {
            return {
                tableID: 'ProInfo',
                total: 100,
                  tableLabel: [
                      { label: '批次号', width: '150', prop: 'wipid', show: true },
                      { label: '剔片人', width: '150', prop: 'userid', show: true },
                      { label: '剔片时间', width: '150', prop: 'scrapdate', show: true },
                      { label: '剔片数量', width: '150', prop: 'scrapqty', show: true },
                      { label: '批次大类', width: '150', prop: 'lottype', show: true },
                      { label: '剔片描述', width: '150', prop: 'detaileddescription', show: true },
                      { label: '剔片编号', width: '150', prop: 'scrapWaferno', show: true },
                      { label: '工艺类型', width: '150', prop: 'process', show: true },
                      { label: '工艺版本', width: '150', prop: 'processver', show: true },
                      { label: '产品名', width: '150', prop: 'productname', show: true },
                      { label: '层次', width: '150', prop: 'stage', show: true },
                      { label: '剔片设备', width: '150', prop: 'equipname', show: true },
                      { label: '批次描述', width: '150', prop: 'lotcomment', show: true },
                      { label: '批次所属人', width: '150', prop: 'lotowner', show: true },
                ],
                tableData: [],
                formData: [],
                form: {
                    activityBeginTime: "",   //异常单填写时间1
                    activityEndTime: "",    //异常单填写时间2
                },
            }

       },
        methods: {
            updateNum(num) {
                this.tableLabel = num;
            },
            QuerySpcList() {
            axios
         //     .post("https://localhost:7155/api/Spc/ScrapLot")
              .post("http://10.163.76.23/api/api/Spc/ScrapLot")
                .then((res) => {
                    this.tableData = res.data;
                    this.total=this.tableData.length
                })
            },
            QueryTimeList() {
                axios
                //     .post("https://localhost:7155/api/Spc/FormTimeLot",this.form)
                .post("http://10.163.76.23/api/api/Spc/FormTimeLot",this.form)
                    .then((res) => {
                        this.tableData = res.data;
                        this.total = this.tableData.length
                    })
            },

        },
        mounted() {
            this.QuerySpcList();
          
            document.title = "Scrap Lot "
        }
    }
</script>

