
<template>
    <!--
                  :data="table.slice((currentPage-1)*pagesize,currentPage*pagesize)"-->
    <el-table :data="table" :show-header="true" :style="{width: '100%', textAlign: 'center', fontSize: '18px'}"
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
            <el-table-column v-if="item.url"
                             :label="item.label"
                             :key="item.prop"
                             :width="item.width">
                <template #default="scope">
                    <el-link :href="generateLink(scope.row, item)"
                             :style="{textAlign: 'center', fontSize: '18px'} "
                             target="_blank" class="buttonText" type="primary" :underline="false"
                             @click="test(scope.row, item)">
                        {{ scope.row[item.prop] }}
                    </el-link>
                </template>
            </el-table-column>
        </template>
    </el-table>


</template>

<style>


</style>
<script>

    export default {
        props: ['table', 'tableLabel' ,'name'],
        data() {
            return {
                selectAll:1,
                pagesize: this.total,
                currentPage: 1,
                dialogFormVisible: false,

                A: [],
            }
        },
    methods: {
        generateLink(row, column ) {
            // 在这个方法中生成带参数的链接
            const param1 = row.产品 ; // 从组件的props或data中获取参数值
            const param2 = column.label;

            // 获取'产品'属性对应的值
        //    const product = row[column.prop];

            // 拼接参数到链接中
            let  link;
            console.log(this.$props.name);
      //      if (this.$props.name == "WaferOut") {
      //           link = `https://localhost:5002/WaferOutTableDay?param1=${param1}&param2=${param2}`;
      //      } else {
      //           link = `https://localhost:5002/WaferStartTableDay?param1=${param1}&param2=${param2}`;
      //      }

                  if (this.$props.name == "WaferOut") {
                 link = `https://10.163.76.23/WaferOutTableDay?param1=${param1}&param2=${param2}`;
            } else {
                 link = `https://10.163.76.23/WaferStartTableDay?param1=${param1}&param2=${param2}`;
            }

            return link;
        },
        test(row, column) {
            console.log('行:', row.产品);
            console.log('列:', column.label);
        }

        }
    }

</script>

