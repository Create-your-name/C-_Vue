<template>
    <div class="table-container">
        <el-form :model="form" label-width="123px" :rules="rules">
            <el-link :href="'http://10.163.76.13:8080/RXPCWEB/DailyReport/FabHoldReport.aspx'">跳转FabHold</el-link>
            <el-tabs type="card" class="demo-tabs">
                <TabTest :table="tableData" :tableLabel="tableLabel" :Tid="tableID" :total="total" @updateNum="updateNum"  :headerCellStyle="headerCellStyle" :rowStyle="rowStyle" :cellStyle="cellStyle"></TabTest>
            </el-tabs>
        </el-form>
    </div>
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
                total: 1000,
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
                tableLabel: [
                    { label: '责任部门', width: '110', prop: 'dept', show: true },
                    { label: 'Target>0h', width: '123', prop: 'target_0', show: true },
                    { label: 'Total Hold时间(Hrs)', width: '200', prop: 'total_HoldTime', show: true },
                    { label: '平均Hold时间(Hrs)', width: '200', prop: 'avg_Hold', show: true },
                    { label: '数量(>12H)', width: '123', prop: 'number_12', halfNumber: true },
                    { label: 'Hold比例（>12H）', width: '123', prop: 'hold__12', show: true },
                    { label: 'Target>12H', width: '130', prop: 'target_12', show: true },
                    { label: '数量>24H', width: '110', prop: 'number_24', DayNumber: true },
                    { label: 'Hold比例（>48H）', width: '120', prop: 'hold__48', show: true },
                    { label: '当前Target>48H', width: '170', prop: 'target_48', show: true },
                { label: '数量(>48H)', width: '120', prop: 'number_48', show: true },
                    { label: '数量', width: '100', prop: 'totalNum', HoldNumber: true },
                    { label: 'Hold 比例', width: '123', prop: 'hold_bl', show: true },
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
                   // .get("https://localhost:7155/api/Rep/HotLot")
                    .get("http://10.163.76.23/api/api/Rep/HotLot")
                    .then((res) => {
                        this.tableData = res.data;
                        this.total = this.tableData.length
                    })
            },

        },
        mounted() {
            this.QuerySpcList();
            document.title = "Hold比例"
        }
    }
</script>


<style>
    .table-container {
        width: 1750px;
        margin: 0 auto;
    }
</style>