
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
                      { label: '品种', width: '150', prop: 'product', show: true },
                      { label: '批次号', width: '150', prop: 'lotid', ENG: true },
                      { label: '数量', width: '80', prop: 'number', show: true },
                      { label: 'LOCATION', width: '140', prop: 'location', show: true },
                      { label: 'Repstage', width: '120', prop: 'repstage', show: true },
                      { label: 'CapaGroup', width: '150', prop: 'capagroup', show: true },
                      { label: '菜单', width: '150', prop: 'repname', show: true },
                      { label: '机台数', width: '80', prop: 'stepNumber', show: true },
                      { label: '状态', width: '120', prop: 'state', show: true },
                      { label: '停留时间', width: '80', prop: 'waitTime', show: true },
                      { label: '下步菜单', width: '150', prop: 'nextStep', show: true },
                      { label: '下步菜单名', width: '150', prop: 'nextRep', show: true },
                      { label: '预计产出时间', width: '150', prop: 'foretime', show: true },
                      { label: 'Move', width: '80', prop: 'hMoveold', show: true },
                      { label: '优先级', width: '100', prop: 'privaite', show: true },
                      { label: '定单时间', width: '180', prop: 'dingdantime', show: true },
                      { label: 'GAP', width: '120', prop: 'gap', show: true },
                      { label: '剩余理论时间', width: '100', prop: 'fore_theoct', show: true },
                      { label: '产品Owner', width: '120', prop: 'owner', show: true },
                      { label: '工艺', width: '180', prop: 'process', show: true },
                      { label: '工艺大类', width: '100', prop: 'processType', show: true },
                      { label: '投片日期', width: '180', prop: 'starttime', show: true },
                      { label: '当前状态时间', width: '100', prop: 'statetime', show: true },
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
                console.log(param1);
                console.log(param2);
                const params = {
                    param1: param1,
                    param2: param2
                 };

                            axios.post("https://localhost:7155/api/Spc/Table/WaferStartTable",params)
                      //         .post("http://10.163.76.23/api/api/Spc/Table/WaferStartTable",params)
                                .then((res) => {
                            this.tableData = res.data;
                                this.total = this.tableData.length
                                })
                            },
                
            }

            }
    

</script>

