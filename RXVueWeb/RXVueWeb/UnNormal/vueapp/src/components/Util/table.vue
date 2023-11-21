
<template>

    <Excel :Tid="Tid"></Excel>
    <el-button type="primary" class="el-icon-s-operation" click @click="ziduanpeizhi">◊÷∂Œ≈‰÷√</el-button>
    <el-table ref="filterTable"
              :id="Tid"
              :data="table.slice((currentPage-1)*pagesize,currentPage*pagesize)"
              size="small"
              row-class-name="row"
              cell-class-name="column"
              :highlight-current-row="true"
              :header-cell-style="{background:'#87cc91',color:'#000000','text-align':'center'}"
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
                             sortable
                             :prop="item.prop"
                             :width="item.width"
                             :label="item.label" />
        </template>
    </el-table>


    <el-dialog v-model="dialogFormVisible" :close-on-click-modal="false" :close-on-press-escape="false">
        <el-row :gutter="20">
            <el-col v-for=" item in A"
                    :key="item.prop"
                    :span="6"
                    style="height:35px">
                <el-checkbox v-if="!item.url1&!item.url2" v-model="item.show">{{ item.label }}</el-checkbox>

            </el-col>
        </el-row>
        <el-button type="danger" @click="saveTableColumns">±£¥Ê◊÷∂Œ≈‰÷√</el-button>
    </el-dialog>



</template>

<script>

   import Excel from '@/components/FromExcel.vue'

    export default {
       components: {
            Excel
        },
        data() {
            return {
            }
        },
        methods: {
           
        }
    }

</script>


