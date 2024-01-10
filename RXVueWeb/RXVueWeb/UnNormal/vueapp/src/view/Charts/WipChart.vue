<template>
    <div style="margin:auto; top: 0; left: 0; width:2850px ; background: rgba(228, 245, 255, 1)">
        <el-row>
            <el-col :span="17">
                <el-text class="mx-1" style=" font-family: '微软雅黑'; font-size: 40px; font-weight: bold;  ">Wafer Start</el-text>
            </el-col>
            <el-col :span="7">
                <el-text class="mx-1" style=" font-family: '微软雅黑'; font-size: 40px; font-weight: bold;  ">MP</el-text>
            </el-col>
        </el-row>
        <el-row>
            <el-col :span="17">
                <div id="MounthChart" ref="MounthChart" class="chart" style=" height: 1000px; width:100%;">
                </div>
            </el-col>
            <el-col :span="7">
                <div id="YearChart" ref="YearChart" class="chart" style=" height: 1000px; width:100%;">
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
        setup() {
            let data = reactive({});
            let xdata = reactive([]);
            let ydata = reactive([]);
            let day = reactive([]);
            let today = 0;

            async function GetData() {
                try {
                    //      display:none;
                 //   const res = await axios.get("https://localhost:7155/api/Charts/Date");
                    const res = await axios.get("http://10.163.76.23/api/api/Charts/Date");
                    data.value = res.data;
                    console.log(data);
                    day = res.data.map(v => v.dateDay).concat(Array.from({ length: 12 }, (_, i) => i + 1 + '月'));
                    var currentDate = new Date();
                    today = currentDate.getDate();
                    console.log(today);
                    // console.log(day);
                } catch (error) {
                    console.error(error);
                }
            }


            async function GetChartsList() {
                try {
                  //  const res = await axios.get("https://localhost:7155/api/Charts/Product");
                    const res = await axios.get("http://10.163.76.23/api/api/Charts/Product");
                    data.value = res.data;
                    //       console.log(data);
                    xdata = res.data.map(v => v.title).slice();
                    ydata = res.data.map(v => v.num).slice();
                } catch (error) {
                    console.error(error);
                }
            }

            onMounted(async () => {
                await GetChartsList().then(async () => {
                    await GetData();
                    let myChart = echarts.init(document.getElementById("MounthChart"));
                    let Year = echarts.init(document.getElementById("YearChart"));
                    Year.setOption({

                        title: [{
                            //             text: 'MP',
                            //           left: "200px",
                            //             textStyle: {
                            //                 fontFamily: 'Microsoft YaHei',
                            //                  fontSize: 30
                            //             },

                        },

                        {
                            text: 'MTD GAP: ',
                            left: "400px",
                        top: "20px",
                            textStyle: {
                                fontFamily: 'Microsoft YaHei',
                                fontWeight: 'bold',
                                fontSize: 27,
                                color: 'black'
                            },
                        },
                        {
                            //text: (((today - 2) >= 0 ? ydata[3][today - 2] : 0) - (ydata[6][ydata[6].length - 1])) + ' pcs \n',
                        text: (((((today - 2) >= 0 ? ydata[3][ydata[3].length - 1] : 0) ) - 442 )) + ' pcs \n',
                            left: "550px",
                             top: "20px",
                            textStyle: {
                                fontFamily: 'Microsoft YaHei',
                                fontWeight: 'bold',
                                fontSize: 27,
                                //color: (((today - 2) >= 0 ? ydata[3][today - 2] : 0) - (ydata[6][ydata[6].length - 1])) < 0 ? 'red' : 'balck',
                            color: (((((today - 2) >= 0 ? ydata[3][ydata[3].length - 1] : 0) )- 442 ))<0 ? 'red' : 'balck',
                            },
                        },
                        {
                           // text: 'ACC Act: ' + ((today - 2) >= 0 ? ydata[3][today - 2] : 0) + ' pcs' + '\n' + 'ACC target:' + (ydata[6][ydata[6].length - 1]) + ' pcs',
                        text: 'ACC Act: ' + (((today - 2) >= 0 ? ydata[3][today - 1] : 0)  )+ ' pcs' + '\n' + 'ACC target: 442 pcs' ,
                            left: "400px",
                            top: "50px",
                            textStyle: {
                                fontFamily: 'Microsoft YaHei',
                                fontWeight: 'bold',
                                fontSize: 27,
                                color: 'black'
                            },
                        }

                        ],
                        tooltip: {
                            trigger: 'axis',
                            axisPointer: {
                                type: 'shadow',
                            },
                        },
                          legend:  {
                        show: false,
                        top: 90,
                        left: 600,
                        width: 'auto',
                        itemHeight: 15,
                        textStyle: {
                            fontSize: '25px',
                            fontWeight: 700
                        },
                        borderColor: 'black', // 设置边框颜色为黑色
                        borderWidth: 3, // 设置边框宽度为3px
                         backgroundColor:'rgba(255,255,255,20)',
                    },
                         grid: {
                        left: '2%',
                        right: '3%',
                        top:'150px',
                         borderColor: 'black',
                         borderWidth: 3, 
                        bottom: '3%',
                        containLabel: true,
                        show:true,
                         backgroundColor:'rgba(255,255,255,20)'
                    },
                       xAxis: [
                        {
                            type: 'category',
                            data: ['1月', '2月', '3月', '4月', '5月', '6月', '7月', '8月', '9月', '10月', '11月', '12月'],
                            axisTick: {
                                show: false,
                            },
                            axisLine: {
                                lineStyle: {
                                    color: '#D5DDE7',
                                },
                            },
                            axisLabel: {
                                    color: 'rgba(0, 0, 0, 0.85)',
                                    fontSize: 27,
                                rotate: -90,
    fontFamily: 'Microsoft YaHei',// 设置为微软雅黑字体
                                },
                        },
                    ],
                        yAxis: [
                            {
                                type: 'value',
                                name: '单位：片',
                                nameTextStyle: {
                                    color: 'rgba(0, 0, 0, 0.6)',
                                    fontSize: 27,
                                },
                                axisLine: {
                                    show: true,
                                    lineStyle: {
                                        color: '#D5DDE7',
                                    },
                                },
                                axisLabel: {
                                    color: 'rgba(0, 0, 0, 0.85)',
                                    fontSize: 27,
                                fontFamily: 'Microsoft YaHei',// 设置为微软雅黑字体
                                },
                            },
                            {
                                type: 'value',
                                position: 'right',
                                nameTextStyle: {
                                    color: 'rgba(0, 0, 0, 0.6)',
                                    fontSize: 27,                                barWidth: '75%',
                                },
                                axisLine: {
                                    show: true,
                                    lineStyle: {
                                        color: '#D5DDE7',
                                    },
                                }, label: {
                                    show: true,
                                    position: 'top',
                                },
                                axisLabel: {
                                    color: 'rgba(0, 0, 0, 0.85)',
                                    fontSize: 27,
                                fontFamily: 'Microsoft YaHei',// 设置为微软雅黑字体
                                },
                            },
                        ],
                        series: [
                            {
                                name: xdata[7],
                                type: 'bar',
                                stack: 'email',
                                barWidth: '75%',
                                itemStyle: { // 自定义柱子颜色
                                    normal: { color: 'rgba(9, 177, 240)', },
                                },
                                emphasis: {
                                    focus: 'series',
                                },

                                data: ydata[7],
                            },
                            {
                                name: xdata[8],
                                type: 'bar',
                                stack: 'email',
                                barWidth: '75%',
                                itemStyle: { // 自定义柱子颜色
                                    normal: { color: 'rgba(193, 191, 154)', },
                                },

                                emphasis: {
                                    focus: 'series',
                                },
                                data: ydata[8],
                            },
                        {
                            name: xdata[9],
                            type: 'bar',
                            stack: 'email',
                            barWidth: '75%',
                            itemStyle: { // 自定义柱子颜色
                                normal: { color: 'rgba(145, 182, 227)', },
                            },

                            emphasis: {
                                focus: 'series',
                            },
                            data: ydata[9],
                        },
                            {
                                name: xdata[26],
                                type: 'bar',
                                stack: 'email',
                                barWidth: '75%',
                                itemStyle: { // 自定义柱子颜色
                                  normal: { color: 'rgba(255,165,0)', },
                                },
                                label: {
                                    normal: {
                                        show: true,
                                        position: 'top',
                                        formatter: function (params) {
                                        return params.value + ydata[8][params.dataIndex] + ydata[7][params.dataIndex] + ydata[9][params.dataIndex]
                                        },
                                        textStyle: {
                                            color: '#000',
                                            fontSize: 25,
                                        fontFamily: 'Microsoft YaHei',// 设置为微软雅黑字体
                                        },
                                    }
                                },
                                emphasis: {
                                    focus: 'series',
                                },
                                data: ydata[26],
                            },
                            {
                                name: 'target',
                                data: ['', '', '', '', '', '', '', '', '', '', '', ''],
                                yAxisIndex: 1,
                                type: 'line',
                                symbol: 'circle',
                                itemStyle: {
                                    normal: {
                                        color: '#73D1F1',
                                        lineStyle: {
                                            width: 6,
                                            type: 'dotted'
                                        },
                                        opacity: 1
                                    }
                                },
                            },
                            {
                                name: 'act',
                            data: ['', '', '', '', '', '', '', '','','','',''],
                                type: 'line',
                                yAxisIndex: 1,
                                smooth: false,
                                itemStyle: {
                                    normal: {
                                        label: { show: true },
                                        color: '#FD3F3F',
                                        lineStyle: {
                                            width: 6,
                                        },
                                        opacity: 0
                                    },
                                },

                            },
                        ],

                    });
                    //  本月
                    myChart.setOption({
                        title: [{


                        },
                        {
                            text: 'MTD GAP: ',
                            left: "1500px",
                            top: "30px",
                            textStyle: {
                                fontFamily: 'Microsoft YaHei',
                                fontWeight: 'bold',
                                fontSize: 27,
                                color: 'black'
                            },
                        },
                        {
                            text: (((ydata[24][0] - 1) >= 0 ? ydata[3][ydata[24][0] - 1] : 0) - ((ydata[24][0] - 2) >= 0 ? ydata[6][ydata[24][0] - 2] : 0)) + ' pcs \n',
                            //假   text: ((ydata[24][0]-2)>=0? (ydata[3][ydata[24][0] - 1] - 1124 ):0) + '\n',
                            left: "1650px",
                            top: "30px",
                            textStyle: {
                                fontFamily: 'Microsoft YaHei',
                                fontWeight: 'bold',
                                fontSize: 27,
                                color: ((((ydata[24][0] - 1) >= 0 ? ydata[3][ydata[24][0] - 1] : 0) - ((ydata[24][0] - 2) >= 0 ? ydata[6][ydata[24][0] - 2] : 0))) < 0 ? 'red' : 'balck'
                                //     color: (((ydata[24][0]-2)>=0?(ydata[3][ydata[24][0] - 1] - 1124 ):0)) <0 ?'red':'balck'
                            },
                        },
                        {
                            text: 'ACC Act: ' + ((ydata[24][0] - 1) >= 0 ? ydata[3][ydata[24][0] - 1] : '0') + 'pcs\n' + 'ACC target: ' + ((ydata[24][0] - 2) >= 0 ? ydata[6][ydata[24][0] - 2] : 0) + 'pcs',
                            // 假   text: 'ACC Act: ' + ((ydata[24][0]-2)>=0?ydata[3][ydata[24][0] - 1]:'0')+ 'pcs \n' + 'ACC target: 1124 pcs',
                            left: "1500px",
                            top: "50px",
                            textStyle: {
                                fontFamily: 'Microsoft YaHei',
                                fontWeight: 'bold',
                                fontSize: 27,
                                color: 'black'
                            },
                        }
                        ],
                        tooltip: {
                            trigger: 'axis',
                            axisPointer: {
                                type: 'shadow',
                            },
                        },
                    legend:  {
                        show: true,
                        top: 90,
                        left: 600,
                        width: 'auto',
                        itemHeight: 15,
                        textStyle: {
                            fontSize: '25px',
                            fontWeight: 700
                        },
                        borderColor: 'black', // 设置边框颜色为黑色
                        borderWidth: 3, // 设置边框宽度为3px
                         backgroundColor:'rgba(255,255,255,20)',
                    },
                        grid: {
                        left: '2%',
                        right: '3%',
                        top:'150px',
                         borderColor: 'black',
                         borderWidth: 3, 
                        bottom: '3%',
                        containLabel: true,
                        show:true,
                         backgroundColor:'rgba(255,255,255,20)'
                    },
                                            xAxis: [
                        {
                            type: 'category',
                            data: day,
                            axisTick: {
                                show: false,
                            },
                            axisLine: {
                                lineStyle: {
                                    color: '#D5DDE7',
                                },
                            },
                           axisLabel: {
                                    color: 'rgba(0, 0, 0, 0.85)',
                                    fontSize: 27,
                                    rotate: -90
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
                                    fontSize: 30,
                                },
                                axisLine: {
                                    show: true,
                                    lineStyle: {
                                        color: '#D5DDE7',
                                    },
                                },
                                axisLabel: {
                                    color: 'rgba(0, 0, 0, 0.85)',
                                    fontSize: 30,
                                },

                            },
                            {
                                type: 'value',
                                position: 'right',
                                nameTextStyle: {
                                    color: 'rgba(0, 0, 0, 0.6)',
                                    fontSize: 30,
                                },
                                axisLine: {
                                    show: true,
                                    lineStyle: {
                                        color: '#D5DDE7',
                                    },
                                }, label: {
                                    show: true,
                                    position: 'top',
                                },
                                axisLabel: {
                                    color: 'rgba(0, 0, 0, 0.85)',
                                    fontSize: 30,
                                },
                            },
                        ],
                        series: [
                        {
                            name: xdata[0],
                            type: 'bar',
                            stack: '总量',
                            barWidth: '75%',
                            itemStyle: {
                                normal: { color: 'rgba(9, 177, 240)', },
                            },
                            emphasis: {
                                focus: 'series',
                            },
                            data: ydata[0]
                        },
                        {
                            name: xdata[1],
                            type: 'bar',
                            stack: '总量',
                            barWidth: '75%',
                            itemStyle: {
                                normal: { color: 'rgba(193, 191, 154)', },
                            },
                            emphasis: {
                                focus: 'series',
                            },
                            data: ydata[1],
                        },
                        {
                            name: xdata[2],
                            type: 'bar',
                            stack: '总量',
                            barWidth: '75%',
                            itemStyle: {
                                normal: { color: 'rgba(145, 182, 227)', },
                            },
                            emphasis: {
                                focus: 'series',
                            },
                            data: ydata[2],
                        },
                        {
                            name: xdata[25],
                            type: 'bar',
                            stack: '总量',
                            barWidth: '75%',
                            itemStyle: {
                                normal: { color: 'rgba(255,165,0)', },
                            },
                            label: {
                                normal: {
                                    show: true,
                                    position: 'top',
                                    formatter: function (params) {
                                        var value = params.value + ydata[1][params.dataIndex] + ydata[0][params.dataIndex] + ydata[2][params.dataIndex];
                                        if (value != 0) {
                                            return value.toFixed(2);
                                        } else {
                                            return "";
                                        }
                                    },
                                    textStyle: {
                                        color: '#000',
                                    fontSize: 20,
                                    }
                                }
                            },
                            emphasis: {
                                focus: 'series',
                            },
                            data: ydata[25],

                        },
                            {
                            name: xdata[22],
                            data: ydata[22],
                               // data: [],
                                type: 'line',
                                smooth: false,
                                symbol: 'circle',
                                itemStyle: {
                                    normal: {
                                        color: '#73D1F1',
                                        lineStyle: {
                                            width: 6,
                                            type: 'dotted'
                                        },
                                        opacity: 1,
                                    }
                                },

                            },
                            {
                                name: xdata[5],
                                // 后端传递过来的 Mp 目标   
                                   data: ydata[5],
                                //data: [72, 72, 72, 72, 72, 72, 72, 72, 72, 72, 72, 72, 72, 72, 72, 72, 72, 72, 72, 72, 72, 72, 72, 72, 72, 72, 72, 72, 72, 72],
                                type: 'line',
                                smooth: false,
                                symbol: 'circle',
                                itemStyle: {
                                    normal: {
                                        color: '#EA2E2E',
                                        lineStyle: {
                                            width: 6,
                                            type: 'dotted'
                                        },
                                        opacity: 1
                                    }
                                },

                            },
                        {
                            name: xdata[3],
                            data: ydata[3],
                            yAxisIndex: 1,
                            color: '#FD3F3F',
                            type: 'line',
                            itemStyle: {
                                normal: {
                                    opacity: 0,
                                    lineStyle: {
                                        width: 6,
                                    }
                                },

                            },
                        },
                            {
                                name: xdata[6],
                                data: ydata[6],
                                yAxisIndex: 1,
                                type: 'line',
                                smooth: false,
                                itemStyle: {
                                    normal: {
                                        color: '#79B8F0',
                                        lineStyle: {
                                            width: 6,
                                            type: 'dotted'
                                        },
                                        opacity: 0
                                    }
                                },

                            },

                        ],
                    });
                });
            });

            return {
                GetChartsList,
                GetData,
                data,
                xdata,
                ydata,
                day,
            };
        },
    };

</script>