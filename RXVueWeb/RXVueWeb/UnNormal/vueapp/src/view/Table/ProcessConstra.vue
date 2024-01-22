 <template>
     <el-form :model="form" label-width="120px" :rules="rules">
         

                 <el-row class="row-bg" justify="space-evenly">
                     <el-col :span="12">
                         <el-form-item label="设备ID" prop="EQPID">
                             <el-input v-model="form.EQPID" style="width:200px" />
                             <el-select v-model="form.EQPID" clearable class="filter-item" placeholder="输入您所需的设备ID">
                                 <el-option v-for="item in uniqueKey(tableData,'eqpid')" :key="item.eqpid" :label="item.eqpid" :value="item.eqpid" />
                             </el-select>
                         </el-form-item>
                     </el-col>
                     <el-col :span="12">
                         <el-form-item label="产品名" prop="Product">
                             <el-input v-model="form.Product" style="width:200px" />
                             <el-select v-model="form.Product" clearable placeholder="输入您所需的产品名">
                                 <el-option v-for="item in uniqueKey(tableData,'product')" :key="item.product" :label="item.product" :value="item.product" />
                             </el-select>
                         </el-form-item>
                     </el-col>
                 </el-row>

                  <el-row class="row-bg" justify="space-evenly">
                     <el-col :span="8">
                         <el-form-item label="工艺大类" prop="Process">
                             <el-input v-model="form.Process" style="width:200px" />
                             <el-select v-model="form.Process" clearable class="filter-item" placeholder="输入您所需的工艺大类">
                                 <el-option v-for="item in uniqueKey(tableData,'process')" :key="item.process" :label="item.process" :value="item.process" />
                             </el-select>
                         </el-form-item>
                     </el-col>
                     <el-col :span="8">
                         <el-form-item label="STAGE" prop="Stage">
                             <el-input v-model="form.Stage" style="width:200px" />
                             <el-select v-model="form.Stage" clearable placeholder="输入您所需的STAGE">
                                 <el-option v-for="item in uniqueKey(tableData,'stage')" :key="item.stage" :label="item.stage" :value="item.stage" />
                             </el-select>
                         </el-form-item>
                     </el-col>
                     <el-col :span="8">
                         <el-form-item label="步骤Step" prop="Step">
                             <el-input v-model="form.Step" style="width:200px" />
                             <el-select v-model="form.Step" clearable class="filter-item" placeholder="输入您所需的步骤Step">
                                 <el-option v-for="item in uniqueKey(tableData,'step')" :key="item.step" :label="item.step" :value="item.step" />
                             </el-select>
                         </el-form-item>
                     </el-col>
                 </el-row>

                  <el-button type="primary" @click="QueryProcessList()" > 查询</el-button>


         <el-tabs type="card" class="demo-tabs">
             <TabTest :table="tableData" :tableLabel="tableLabel" :Tid="tableID" :total="total" @updateNum="updateNum" :headerCellStyle="headerCellStyle" :rowStyle="rowStyle" :cellStyle="cellStyle" :height="750" ></TabTest>
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
            headerCellStyle: {
                background: '#11C4CA',
                color: '#ffffff',
                'text-align': 'center',
                'font-size': '20px'
            },
            rowStyle: {
                background: '#E5EAC6',
                height: '5px'
            },
            cellStyle: {
                'text-align': 'center',
                'border': '1px solid #E2DDF6',
                'font-size': '25px'
                },
            form: {
                EQPID: "",
                Product: "",
                Process: "",
                Stage: "",
                Step:"",
            },
                tableID: 'Process',
                total: 20,

                tableLabel: [
                { label: '设备ID', width: '180', prop: 'eqpid', show: true },
                { label: 'ectp', width: '60', prop: 'ectp', show: true },
                { label: 'ckord', width: '80', prop: 'ckord', show: true },
                { label: '产品名', width: '250', prop: 'product', show: true },
                { label: '工艺大类', width: '250', prop: 'process', show: true },
                { label: 'STAGE', width: '120', prop: 'stage', show: true },
                { label: '菜单名', width: '250', prop: 'recipe', show: true },
                { label: '用户名', width: '150', prop: 'userid', show: true },
                { label: 'DOCID', width: '120', prop: 'docid', show: true },
                { label: 'DOCTP', width: '100', prop: 'doctp', show: true },
                { label: 'CST描述', width: '180', prop: 'cstDes', show: true },
                { label: '批号', width: '180', prop: 'lotid', show: true },
                { label: '状态', width: '200', prop: 'status', show: true },
                { label: '设备组', width: '80', prop: 'eqpgroup', show: true },
                { label: '描述', width: '100', prop: 'description', show: true },
                ],
                tableData: [],
                formData: [],
            }

       },
        methods: {
            updateNum(num) {
                this.tableLabel = num;
            },
            uniqueKey(array, key) {
                return array.reduce((result, item) => {
                    if (!result.find(e => e[key] === item[key]) && item[key] != null) {
                        result.push(item);
                    }
                    return result;
                }, []);
            },
            QuerySpcList() {
            axios
         //     .get("https://localhost:7155/api/Spc/Table/ProcessTableList")
              .get("http://10.163.76.23/api/api/Spc/Table/ProcessTableList")
                .then((res) => {
                    this.tableData = res.data;
                               this.total=this.tableData.length
                })
            },
            QueryProcessList() {
                axios
                  //.post("https://localhost:7155/api/Spc/Table/ProcessTable", this.form)
                     .post("http://10.163.76.23/api/api/Spc/Table/ProcessTable", this.form)
                    .then((res) => {
                        this.tableData = res.data;
                                   this.total=this.tableData.length
                    })
                },

        },
        mounted() {
            this.QuerySpcList();
          
            document.title = "工艺限制报表"
        }
    }
</script>

