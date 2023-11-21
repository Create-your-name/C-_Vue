
<template>

    <el-button type="primary" @click="exportExcel()">导出</el-button>
</template>

<script>

    import FileSaver from "file-saver"
    import * as XLSX from "xlsx";
    export default {
        props: ['Tid'],
        methods: {
            exportExcel() {
                //转换成excel时，使用原始的格式
                var xlsxParam = { raw: true };
                let fix = document.querySelector(".el-table__fixed");
                let wb;
                //判断有无fixed定位，如果有的话去掉，后面再加上，不然数据会重复
                if (fix) {
                    wb = XLSX.utils.table_to_book(
                        document.getElementById(this.Tid).removeChild(fix), xlsxParam
                    );
                    document.getElementById(this.Tid).appendChild(fix);
                } else {
                    wb = XLSX.utils.table_to_book(document.getElementById(this.Tid), xlsxParam);
                }
                console.log(this.Tid);
                var wbout = XLSX.write(wb, {
                    bookType: "xlsx",
                    bookSST: true,
                    type: "array",
                });
                try {
                    FileSaver.saveAs(
                        new Blob([wbout], { type: "application/octet-stream" }),
                        "导出详情单.xlsx"
                    ); //文件名
                } catch (e) {
                    if (typeof console !== "undefined") console.log(e, wbout);
                }
                return wbout;
            }
        }
    }

</script>
