 <template>
     <el-form :model="form" label-width="120px" :rules="rules">
         <el-button type="primary" > 查询</el-button>
         <el-tabs type="card" class="demo-tabs">
             <TabTest :table="tableData" :tableLabel="tableLabel" :Tid="tableID" :total="total" @updateNum="updateNum" :headerCellStyle="headerCellStyle" :rowStyle="rowStyle" :cellStyle="cellStyle" :height="750" :totalname="true"></TabTest>
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
                tableID: 'ProInfo',
                total: 20,
                  tableLabel: [
                      { label: '品种', width: '250', prop: 'product', show: true },
                      { label: '批次号', width: '150', prop: 'lotid', ENG: true },
                      { label: '数量', width: '80', prop: 'number', show: true },
                      { label: 'LOCATION', width: '150', prop: 'location', show: true },
                      { label: 'Repstage', width: '150', prop: 'repstage', show: true },
                      { label: 'CapaGroup', width: '300', prop: 'capagroup', show: true },
                      { label: '菜单', width: '200', prop: 'repname', show: true },
                      { label: '机台数', width: '80', prop: 'stepNumber', show: true },
                      { label: '状态', width: '120', prop: 'state', show: true },
                      { label: '停留时间', width: '100', prop: 'waitTime', show: true },
                      { label: '下步菜单', width: '250', prop: 'nextStep', show: true },
                      { label: '下步菜单名', width: '250', prop: 'nextRep', show: true },
                      { label: '预计产出时间', width: '250', prop: 'foretime', show: true },
                      { label: 'Move', width: '80', prop: 'hMoveold', show: true },
                      { label: '优先级', width: '100', prop: 'privaite', show: true },
                      { label: '定单时间', width: '250', prop: 'dingdantime', show: true },
                      { label: 'GAP', width: '120', prop: 'gap', show: true },
                      { label: '剩余理论时间', width: '100', prop: 'fore_theoct', show: true },
                      { label: '产品Owner', width: '100', prop: 'owner', show: true },
                      { label: '工艺', width: '250', prop: 'process', show: true },
                      { label: '工艺大类', width: '100', prop: 'processType', show: true },
                      { label: '投片日期', width: '250', prop: 'starttime', show: true },
                      { label: '当前状态时间', width: '150', prop: 'statetime', show: true },

                { label: '申请部门', width: '100', prop: 'department', show: true },
                { label: '申请时间', width: '250', prop: 'requestTime', show: true },
                { label: '目的', width: '150', prop: 'aim', show: true },
                ],
                tableData: [],
                formData: [],
            }

       },
        methods: {
            updateNum(num) {
                this.tableLabel = num;
            },
            QuerySpcList() {
            axios
              .post("https://localhost:7155/api/Spc/Table/EngLot")
          //    .post("http://10.163.76.23/api/api/Spc/Table/EngLot")
                .then((res) => {
                    this.tableData = res.data;
                    this.total = this.tableData.length
                })
            },

        },
        mounted() {
            this.QuerySpcList();
          
            document.title = "工程批信息 "
        }
    }
</script>

