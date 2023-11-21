<template>
    <div style="margin:auto; top: 0; left: 0; background: rgba(228, 245, 255, 1) ">
        <el-row class="row-bg" justify="space-evenly">
            <el-col :span="12">
                <el-form-item label="工艺大类" prop="Process">
                    <el-select v-model="form.Process" clearable placeholder="输入您所需的工艺大类">
                        <el-option v-for="item in uniqueKey(tableData,'processtype')" :key="item.processtype" :label="item.processtype"
                                   :value="item.processtype" />
                    </el-select>
                </el-form-item>
            </el-col>
            <el-col :span="8">
                <el-form-item label="产品名称" prop="Product">
                    <el-select v-model="form.Product" clearable placeholder="请输入产品名称">
                        <el-option v-for="item in uniqueKey(tableData,'partname')" :key="item.partname" :label="item.partname"
                                   :value="item.partname" />
                    </el-select>
                </el-form-item>
            </el-col>
            <el-col :span="4">
                <el-button type="primary" @click="getDataList"> 查询</el-button>
            </el-col>
        </el-row>
        <el-row>
            <el-col :span="24">
                <div id="WipMove" ref="WipMove" class="chart" style=" height: 1000px; width:100%;">
                </div>
            </el-col>

        </el-row>
    </div>
</template>
<script>
    import { reactive, onMounted } from 'vue';
    import axios from 'axios';
    import * as echarts from 'echarts';

    export default {
        data() {
            return {
            form: {
                Process: "", //工艺大类
                Product: "", //产品名称
                },
            tableData: [],
            }
        },
         methods: {
                QueryDepartList() {
                    axios
                     //      .get("https://localhost:7155/api/Rep/GetPro")
                            .get("http://10.163.76.23/api/api/Rep/GetPro")
                        .then((res) => {
                            this.tableData = res.data;
                        })
                     },
                uniqueKey(array, key) {
                    return array.reduce((result, item) => {
                        if (!result.find(e => e[key] === item[key]) && item[key] != null) {
                            result.push(item);
                        }
                        return result;
                    }, []);
                },
                getDataList(){
                   //  axios.post("https://localhost:7155/api/Rep/PostPro", this.form)
                      axios.post("http://10.163.76.23/api/api/Rep/PostPro", this.form)
                    .then((res) => {
                        this.data.value = res.data;
                        this.xdata = res.data.map(v => v.desc).slice();
                        this.ydata = res.data.map(v => v.recpDesc).slice();
                        console.log(this.data);
                        console.log(this.xdata);
                        console.log(this.ydata);
                        this.updateChartOptions(this.xdata,this.ydata);
                    }).catch(err => {
                        console.log(err)
                    })
            }
        },
    setup() {
        let data = reactive({});
        let xdata = reactive([]);
        let ydata = reactive([]);


            async function GetChartsList() {
                try {
                 //   const res = await axios.get("https://localhost:7155/api/Rep/WipMove");
                    const res = await axios.get("http://10.163.76.23/api/api/Rep/WipMove");
                    data.value = res.data;
                    xdata = res.data.map(v => v.desc).slice();
                    ydata = res.data.map(v => v.recpDesc).slice();
                    console.log(data);
                    console.log(xdata);
                    console.log(ydata);
                    this

                } catch (error) {
                    console.error(error);
                }
            }
        function updateChartOptions(xdata, ydata) {
            let myChart = echarts.init(document.getElementById("WipMove"));
                let option = {
                    // ... existing options for the chart
                    xAxis: [
                        {
                            // ... existing options for the xAxis
                            data: ydata[0], // update the data for the xAxis
                        },
                    ],
                    series: [
                        {
                            name: xdata[1],
                            // ... existing options for the series
                            data: ydata[1], // update the data for the series
                        },
                        {
                            name: xdata[2],
                            // ... existing options for the series
                            data: ydata[2], // update the data for the series
                        },
                        {
                            name: xdata[3],
                            // ... existing options for the series
                            data: ydata[3], // update the data for the series
                        },
                        {
                            name: xdata[4],
                            // ... existing options for the series
                            data: ydata[4], // update the data for the series
                        },
                    ],
                };

                myChart.setOption(option); // set the new options for the chart
            }
            onMounted(async () => {
                await GetChartsList().then(() => {
             
                    let myChart = echarts.init(document.getElementById("WipMove"));
                    var sum = 0;
                    for (var i = 0; i < ydata[1].length; i++) {
                    sum += parseInt(ydata[1][i]) + parseInt(ydata[2][i]) + parseInt(ydata[3][i]);
                    }
                    myChart.setOption( {
                        title: [{
                            text: "在线WIP：" + sum + "片",
                              left: "500px",
                            textStyle: {
                                fontFamily: 'Microsoft YaHei',
                                fontWeight: 'bold',
                                fontSize: 30,
                                color: 'black'
                            },
                        },
                        ],
                        tooltip: {
                            trigger: 'axis',
                            axisPointer: {
                                type: 'shadow',
                            },
                        },
                        legend: {
                            show: true,
                        },
                        grid: {
                            left: '2%',
                            right: '%',
                            bottom: '3%',
                            containLabel: true,
                            show: true,
                            backgroundColor: 'rgba(255,255,255,20)'
                        },
                        xAxis: [
                            {
                                type: 'category',
                                data: ydata[0],
                                axisTick: {
                                    show: false,
                                },
                                minInterval: 1,
                                axisLine: {
                                    lineStyle: {
                                        color: 'rgba(0, 0, 0, 0.85)',
                                    },
                                },
                                axisLabel: {
                                    color: 'rgba(0, 0, 0, 0.85)',
                                    fontSize: 15,
                                    rotate: -45
                                },

                                scrollable: true
                            },
                        ],
                        yAxis: [
                            {
                                type: 'value',
                                name: '单位：片',
                                nameTextStyle: {
                                    color: 'rgba(0, 0, 0, 0.6)',
                                    fontSize: 15,
                                },
                                axisLine: {
                                    show: true,
                                    lineStyle: {
                                        color: '#D5DDE7',
                                    },
                                },
                                axisLabel: {
                                    color: 'rgba(0, 0, 0, 0.85)',
                                    fontSize: 15,
                                },

                            },
                        ],
                        dataZoom: [
                            {
                                type: 'slider',
                                show: true,
                                xAxisIndex: [0],
                                start: 1,
                                end: 35
                            },
                            {
                                type: 'inside',
                                xAxisIndex: [0],
                                start: 1,
                                end: 35
                            },
                        ],
                        series: [
                            {
                                name: xdata[1],
                                type: 'bar',
                                stack: '总量',
                                barWidth: 14,
                                itemStyle: {
                                normal: { color: 'rgba(255,0,0)', },
                                },
                                emphasis: {
                                    focus: 'series',
                                },
                                data: ydata[1]
                            },
                            {
                                name: xdata[2],
                                type: 'bar',
                                stack: '总量',
                                barWidth: 14,
                                itemStyle: {
                                    normal: { color: 'rgba(144,238,144)', },
                                },
                                emphasis: {
                                    focus: 'series',
                                },
                                data: ydata[2],
                            },
                            {
                                name: xdata[3],
                                type: 'bar',
                                stack: '总量',
                                barWidth: 14,
                                itemStyle: {
                                normal: { color: 'rgba(255,228,181)', },
                                },
                                emphasis: {
                                    focus: 'series',
                                },
                                data: ydata[3],
                            },
                            {
                            name: "MOVE",
                            type: 'scatter',
                                stack: '总量',
                                barWidth: 14,
                                itemStyle: {
                                    normal: { color: 'rgba(255,160,122)', },
                                },
                                emphasis: {
                                    focus: 'series',
                                },
                            data: ydata[4] ? ydata[4]:[0],
                            },



                        ],
                    }
                    );
                })});
            return {
            data ,
            xdata ,
            ydata,
            updateChartOptions
            };
    },
    mounted() {
        this.QueryDepartList();
        document.title = "Stage Wip 报表"
    },
    };

</script>