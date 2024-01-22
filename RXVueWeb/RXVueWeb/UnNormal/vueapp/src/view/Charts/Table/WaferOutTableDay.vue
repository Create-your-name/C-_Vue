
<template>
    <!--
                  :data="table.slice((currentPage-1)*pagesize,currentPage*pagesize)"-->
    <el-table :data="tableData" :show-header="true" :style="{width: '100%', textAlign: 'center', fontSize: '18px'}"
              :row-style="{textAlign: 'center', fontSize: '16px',background: 'rgba(253 ,245, 230 ,1)'} "
              :header-cell-style="{fontSize: '16px', background: 'rgba(228, 245, 255, 1)'}">
        <template v-for=" item in tableLabel">
            <el-table-column v-if="item.show"
                             :key="item.prop"
                             :show-overflow-tooltip="true"
                             sortable
                             :prop="item.prop"
                             :width="item.width"
                             :label="item.label" />
        </template>
    </el-table>


</template>

<style>


</style>
<script>

    import axios from "axios";

    export default {
        data() {
            return {
            param1: '', // 定义param1变量
                    param2: '', // 定义param2变量
                tableData:[],
             tableLabel: [
                { label: '品种', width: '250', prop: 'product', show: true },
                { label: '批次号', width: '150', prop: 'lotid', ENG: true },
                { label: '数量', width: '180', prop: 'number', show: true },
                { label: '等待时间', width: '150', prop: 'waitTime', show: true },
                { label: 'Hold时间', width: '150', prop: 'hold', show: true },
                { label: 'Run货时间', width: '300', prop: 'nextStep', show: true },
                { label: '工艺大类', width: '200', prop: 'nextRep', show: true },
                { label: '开始时间', width: '250', prop: 'gap', show: true },
                { label: 'Qa栈点时间', width: '180', prop: 'foretime', show: true },
                { label: '工艺类型', width: '150', prop: 'hMoveold', show: true },
                { label: '优先级', width: '100', prop: 'runtime', show: true },
                { label: '光刻层数', width: '250', prop: 'privaite', show: true },
                { label: '总步数', width: '180', prop: 'fore_theoct', show: true },
                { label: '批次所属人', width: '150', prop: 'aim', show: true },
                { label: '工单号', width: '250', prop: 'dingdantime', show: true },

                ],
            }
        },
        created() {
            this.test();
        },
        methods: {
            test(row, column) {
                const searchParams = new URLSearchParams(window.location.search);
                const param1 = searchParams.get('param1');
                const param2 = searchParams.get('param2');
                console.log(row);
                console.log(column);
                const params = {
                    param1: param1,
                    param2: param2
                 };

                            axios.post("https://localhost:7155/api/Spc/Table/WaferOutTable",params)
                  //         .post("http://10.163.76.23/api/api/Spc/Table/WaferOutTable",params)
                                .then((res) => {
                            this.tableData = res.data;
                                this.total = this.tableData.length
                                })
                            },
                
            }

            }
    

</script>

