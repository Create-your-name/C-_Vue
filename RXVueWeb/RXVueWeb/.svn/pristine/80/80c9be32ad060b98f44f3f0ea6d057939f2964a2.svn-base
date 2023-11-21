
<template>

    <el-button type="primary" class="el-icon-s-operation" click @click="ziduanpeizhi">字段配置</el-button>
    <el-table ref="filterTable"
              :id="Tid"
              :data="table.slice((currentPage-1)*pagesize,currentPage*pagesize)"
              size="small"
              row-class-name="row"
              cell-class-name="column"
              :highlight-current-row="true"
              :header-cell-style="{background:'#9ACD32',color:'#000000','text-align':'center'}"
              :row-style="{background:'#AFEEEE',height:5+'px'}"
              :cell-style="{'text-align':'center'}"
              @cell-click="clickRow"
              @row-click="test"
              @row-dblclick="rowdblclick"
              @selection-change="SelectChange"
              v-horizontal-scroll="'always'">
        <template v-for=" item in tableLabel">
            <el-table-column v-if="item.show"
                             :key="item.prop"
                             :show-overflow-tooltip="true"
                             :prop="item.prop"
                             :width="item.width"
                             :label="item.label" />
        </template>
    </el-table>

    <div style="text-align:center">
        <el-pagination hide-on-single-page background layout="prev, pager, next,total" :total="total" :page-size="pagesize" @current-change="current_change"></el-pagination>
    </div>

    <el-dialog v-model="dialogFormVisible" :close-on-click-modal="false" :close-on-press-escape="false">
        <el-row :gutter="20">
            <el-col v-for=" item in A"
                    :key="item.prop"
                    :span="6"
                    style="height:35px">
                <el-checkbox v-if="!item.url1&!item.url2" v-model="item.show">{{ item.label }}</el-checkbox>
            </el-col>
        </el-row>
        <el-button type="danger" @click="saveTableColumns">保存字段配置</el-button>
    </el-dialog>



</template>
<script>

 export default {
        props: ['table', 'tableLabel', 'Tid','total'],
        data() {
            return {


            pagesize: 20,
            currentPage: 1,

                dialogFormVisible: false,

                A: [],
            }
        },
        methods: {
            test(row) {
                console.log('被点击了');
                console.log(row.pid);
                console.log(this.A);
            },
            ziduanpeizhi() {
                this.A = JSON.parse(JSON.stringify(this.tableLabel));

                this.dialogFormVisible = true;
            },
            saveTableColumns() {
                this.$emit("updateNum", this.A)
                this.dialogFormVisible = false;
            },
        }
    }

</script>