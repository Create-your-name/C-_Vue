<template>
    <div style="margin:auto; top: 0; left: 0; width:2850px ; background: rgba(228, 245, 255, 1); ">
        <el-row>
            <el-col :span="17">
                <el-text class="mx-1" style="font-family: '微软雅黑'; font-size: 40px; font-weight: bold;">Wafer Out</el-text>
            </el-col>
            <el-col :span="7">
                <el-text class="mx-1" style=" font-family: '微软雅黑'; font-size: 40px; font-weight: bold;">MP</el-text>
            </el-col>
        </el-row>
        <el-row>
            <el-col :span="17">
                <div id="MounthOut" ref="MounthOut" class="chart"
                     style=" height: 1000px; width:100%;">
                </div>
            </el-col>
            <el-col :span="7">
                <div id="YearOut" ref="YearOut" class="chart"
                     style=" height: 1000px; width:100%;">
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
              //  const res = await axios.get("https://localhost:7155/api/Charts/Date");
                const res = await axios.get("http://10.163.76.23/api/api/Charts/Date");
                data.value = res.data;
                console.log(data);
                day = res.data.map(v => v.dateDay).concat(Array.from({length: 12}, (_, i) => i + 1 +'月'));
                var currentDate = new Date();
                today = currentDate.getDate();
                console.log(today);
              } catch (error) {
                console.error(error);
              }
            }


            async function GetChartsList() {
                try {
              //     const res = await axios.get("https://localhost:7155/api/Charts/Product");
                     const res = await axios.get("http://10.163.76.23/api/api/Charts/Product");
                    data.value = res.data;
             //       console.log(data);
                    xdata = res.data.map(v => v.title).slice();
                    ydata = res.data.map(v => v.num).slice();

                 //    console.log(ydata);
                } catch (error) {
                    console.error(error);
                }
            }

            onMounted(async () => {
                await GetChartsList().then(async () => {
                    await GetData();
                    let WaferOut = echarts.init(document.getElementById("MounthOut"));
                    let YearOut = echarts.init(document.getElementById("YearOut"));

                WaferOut.setOption({
                    title: [{

                    },

                    {
                        text: 'MTD GAP: ',
                        left: "1450px",
                       top: "0px",
                        textStyle: {
                            fontFamily: 'Microsoft YaHei',
                            fontWeight: 'bold',
                            fontSize: 25,
                            color: 'black'
                        },
                    },
                    {
                        text: ((ydata[24][0]-2)>=0?(ydata[13][ydata[24][0] - 1] - ydata[16][ydata[24][0] - 1] ):0) + ' pcs' + '\n' ,
                        left: "1600px",
                         top: "0px",
                        textStyle: {
                            fontFamily: 'Microsoft YaHei',
                            fontWeight: 'bold',
                            fontSize: 25,
                            color: (((ydata[24][0]-2)>=0?(ydata[13][ydata[24][0] - 1] - ydata[16][ydata[24][0] - 1]):0)) < 0 ? 'red' : 'balck'
                        },
                    },
                    {
                        text:  'ACC Act: ' +( (ydata[24][0]-2)>=0?ydata[13][ydata[24][0] - 1]:0) + ' pcs' + '\n' + 'ACC target: ' + (ydata[16][ydata[24][0] - 1]) + ' pcs'  ,
                        left: "1450px",
                        top: "20px",
                        textStyle: {
                            fontFamily: 'Microsoft YaHei',
                            fontWeight: 'bold',
                            fontSize: 25,
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
                                rotate: -90,
                                fontFamily: 'Microsoft YaHei' ,// 设置为微软雅黑字体
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
                                fontFamily: 'Microsoft YaHei',// 设置为微软雅黑字体
                            },
                            min:0,
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
                                                        min: 0,
                            axisLabel: {
                                color: 'rgba(0, 0, 0, 0.85)',
                                fontSize: 30,
                                fontFamily: 'Microsoft YaHei',// 设置为微软雅黑字体
                            },
                        },
                    ],
                    series: [
                        {
                            name: xdata[10],
                            type: 'bar',
                            stack: '总量',
                            barWidth: '75%',
                            itemStyle: {
                                normal: { color: 'rgba(9, 177, 240)', },
                            },
                            emphasis: {
                                focus: 'series',
                            },
                            data: ydata[10]
                        },
                        {
                            name: xdata[11],
                            type: 'bar',
                            stack: '总量',
                            barWidth: '75%',
                            itemStyle: {
                                normal: { color: 'rgba(193, 191, 154)', },
                            },
                            emphasis: {
                                focus: 'series',
                            },
                            data: ydata[11],
                        },
                        {
                            name: xdata[12],
                            type: 'bar',
                            stack: '总量',
                            barWidth: '75%',
                            itemStyle: {
                                normal: { color: 'rgba(145, 182, 227)', },
                            },
                            label: {
                                normal: {
                                    show: true,
                                    position: 'top',
                                    formatter: function (params) {

                                        var value = params.value + ydata[10][params.dataIndex] + ydata[11][params.dataIndex];
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
                            data: ydata[12],

                        },
                        {
                            name: xdata[23],
                            data: ydata[23],
                           // data: [49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49],
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
                                    opacity: 1
                                }
                            },

                        },
                        {
                            name: xdata[15],
                          // 后端 传值 MP  data: ydata[15],
                            data: ydata[15],
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
                            name: xdata[13],
                            data: ydata[13],
                            yAxisIndex: 1,
                            color: '#FD3F3F',
                            type: 'line',
                            itemStyle: {
                                opacity: 0,
                                normal: {
                                    lineStyle: {
                                        width: 6,
                                    },
                                }
                            },
                        },
                        {
                            name: xdata[16],
                            data: ydata[16],
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
                                },
                            },

                        },
                       

                    ],
                });

                    YearOut.setOption({
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
                        top: "30px",
                        left: "400px",
                        textStyle: {
                            fontFamily: 'Microsoft YaHei',
                            fontWeight: 'bold',
                            fontSize: 25,
                            color: 'black'
                        },
                    },
                    {
                        text: (ydata[20][ydata[20].length -1] + 40 - 6000 ) + ' pcs' + '\n',
                        left: "550px", 
                                                top: "30px",
                        textStyle: {
                            fontFamily: 'Microsoft YaHei',
                            fontWeight: 'bold',
                            fontSize: 25,
                            color: ((ydata[20][ydata[20].length-1] + 40 - 6000)) < 0 ? 'red' : 'balck'
                        },
                    },
                    {
                        text:  'ACC Act: ' + ( ydata[20][ydata[20].length-1] + 40 )   + ' pcs' + '\n' + 'ACC target: 6000  pcs',
                        left: "400px",
                        top: "60px",
                        textStyle: {
                            fontFamily: 'Microsoft YaHei',
                            fontWeight: 'bold',
                            fontSize: 25,
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
                                    rotate: -90
                                },
                        },
                    ],
                    yAxis: [
                        {
                            type: 'value',
                            name: '单位：片',
                            nameTextStyle: {
                                color: 'rgba(0, 0, 0, 0.6)',
                                fontSize: 25,
                            },
                            axisLine: {
                                show: true,
                                lineStyle: {
                                    color: '#D5DDE7',
                                },
                            },
                            axisLabel: {
                                color: 'rgba(0, 0, 0, 0.85)',
                                fontSize: 25,
                            },
                        },
                        {
                            type: 'value',
                            position: 'right',
                            nameTextStyle: {
                                color: 'rgba(0, 0, 0, 0.6)',
                                fontSize: 15,
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
                                fontSize: 25,
                            },
                        },
                    ],
                    series: [
                        {
                            name: xdata[17],
                            type: 'bar',
                            stack: 'email',
                            barWidth: '75%',
                            itemStyle: { // 自定义柱子颜色
                                normal: { color: 'rgba(9, 177, 240)', },

                            },
                            emphasis: {
                                focus: 'series',
                            },

                            data: ydata[17],
                        },
                        {
                            name: xdata[18],
                            type: 'bar',
                            stack: 'email',
                             barWidth: '75%',
                            itemStyle: { // 自定义柱子颜色
                                normal: { color: 'rgba(193, 191, 154)', },
                            },

                            emphasis: {
                                focus: 'series',
                            },
                            data: ydata[18],
                        },
                        {
                            name: xdata[19],
                            type: 'bar',
                            stack: 'email',
                             barWidth: '75%',
                            itemStyle: { // 自定义柱子颜色
                                normal: { color: 'rgba(145, 182, 227)', },
                            },
                            label: {
                                normal: {
                                    show: true,
                                    position: 'top',
                                    formatter: function (params) {
                                        if (params.value + ydata[18][params.dataIndex] + ydata[17][params.dataIndex] != 0) {
                                            return params.value + ydata[18][params.dataIndex] + ydata[17][params.dataIndex] 
                                        } else {
                                            return""
                                        }
                                       
                                    },
                                    textStyle: {
                                        color: '#000',
                                        fontSize: 25,
                                    }
                                }
                            },
                            emphasis: {
                                focus: 'series',
                            },
                            data: ydata[19],
                        },
                        {
                            name: 'target',
                            data: ['','' ,'','' ,'' ,'' ,'' , 159, 827,	2327,3803,6003 ],
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
                            data: ['', '', '', '', '', '', '', 159, 497, 1503, ydata[20][ydata[20].length - 1]+40 ],
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