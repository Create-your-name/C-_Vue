﻿ <template>
     <el-form :model="form" label-width="120px" :rules="rules">
         <el-button type="primary" > 查询</el-button>
         <el-tabs type="card" class="demo-tabs">
             <TabTest :table="tableData" :tableLabel="tableLabel" :Tid="tableID" :total="total" @updateNum="updateNum" :headerCellStyle="headerCellStyle" :rowStyle="rowStyle" :cellStyle="cellStyle"></TabTest>
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
                background: '#4474B3',
                color: '#ffffff',
                'text-align': 'center',
                'font-size': '20px'
            },
            rowStyle: {
                background: '#ffffff',
                height: '5px'
            },
            cellStyle: {
                'text-align': 'center',
                'border': '1px solid #E2DDF6',
                'font-size': '25px'
            },
                tableID: 'ProInfo',
                total: 100,
                  tableLabel: [
                      { label: '优先级', width: '150', prop: 'priority', show: true },
                      { label: '批次所属部门', width: '150', prop: 'location', show: true },
                      { label: '产品名', width: '150', prop: 'partname', show: true },
                      { label: '批次号', width: '150', prop: 'lotid', show: true },
                      { label: '批次状态', width: '150', prop: 'stage', show: true },
                      { label: '数量', width: '150', prop: 'curmainqty', show: true },
                      { label: '投料时间', width: '150', prop: 'createtime', show: true },
                      { label: '计划产出时间', width: '150', prop: 'outdate', show: true },
                      { label: 'Forcast产出时间', width: '150', prop: 'endline', show: true },
                      { label: '当前步骤', width: '150', prop: 'capaGroup', show: true },
                      { label: '白班预计到达站点', width: '150', prop: 'ph', show: true },
                      { label: '总工步数', width: '150', prop: 'totalstep', show: true },
                      { label: '已完成步数', width: '150', prop: 'nowStep', show: true },
                      { label: '剩余步数', width: '150', prop: 'remStep', show: true },
                      { label: '当前步骤时间(小时)', width: '150', prop: 'nexttime', show: true },
                      { label: '流片完成度', width: '150', prop: 'bfb', show: true },
                      { label: '备注', width: '150', prop: 'ph', show: true },
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
         //     .post("https://localhost:7155/api/Spc/SpcLot")
              .post("http://10.163.76.23/api/api/Spc/SpcLot")
                .then((res) => {
                    this.tableData = res.data;
                    this.total=this.tableData.length
                })
            },

        },
        mounted() {
            this.QuerySpcList();
          
            document.title = "Spc Lot "
        }
    }
</script>

