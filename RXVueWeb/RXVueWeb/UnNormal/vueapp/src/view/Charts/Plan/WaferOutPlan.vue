<template>
    <div style="margin:auto; top: 0; left: 0; width:2850px ; background: rgba(228, 245, 255, 1); ">
        <el-row>
            <el-col :span="17">
                <el-text class="mx-1" style="font-family: '微软雅黑'; font-size: 40px; font-weight: bold;">产出计划</el-text>
            </el-col>
        </el-row>
        <el-row>
            <el-col :span="24">
                <div id="MounthOut" ref="MounthOut" class="chart"
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

            let xldata = reactive([]);
            let yldata = reactive([]);

        async function GetData() {
            try {
                  const res = await axios.get("https://localhost:7155/api/Charts/Date");
                //const res = await axios.get("http://10.163.76.23/api/api/Charts/Date");
                data.value = res.data;
                console.log(data);
                day = res.data.map(v => v.dateDay).concat(Array.from({ length: 0 }, (_, i) => i + 1 + '月'));
                var currentDate = new Date();
                today = currentDate.getDate();
                console.log(today);
            } catch (error) {
                console.error(error);
            }
        }


            async function GetChartsList() {
                try {
                   const res = await axios.get("https://localhost:7155/api/Charts/Product");
              //       const res = await axios.get("http://10.163.76.23/api/api/Charts/Product");
                    data.value = res.data;
                    day = res.data.map(v => v.dateDay).concat(Array.from({ length: 0 }, (_, i) => i + 1 + '月'));
             //       console.log(data);
                    xdata = res.data.map(v => v.title).slice();
                    ydata = res.data.map(v => v.num).slice();

                 //    console.log(ydata);
                } catch (error) {
                    console.error(error);
                }
            }

            async function GetThisChartsList() {
                try {
                    const  res2  = await axios.get("https://localhost:7155/api/MonthPlan/Plan");
                    // res = await axios.get("http://10.163.76.23/api/api/MonthPlan/Plan");
                 //       console.log(data);
                        xldata = res2.data.map(v => v.title).slice();
                        yldata = res2.data.map(v => v.num).slice();

                     //    console.log(ydata);
                    } catch (error) {
                        console.error(error);
                    }
                }

            onMounted(async () => {
                await GetChartsList().then(async () => {
                    await GetData();
                    await GetThisChartsList();
                    let WaferOut = echarts.init(document.getElementById("MounthOut"));

                WaferOut.setOption({
                    title: [

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
                            name: xldata[0],
                            data: yldata[0],
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
                            name: xldata[1],
                            data: yldata[1],
                           // data: [49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49],
                            type: 'bar',
                           
                            smooth: false,
                            stack: '总量',
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
                            name: xldata[2],
                            data: yldata[2],
                            type: 'line',
                           
                            smooth: false,
                            symbol: 'circle',
                            itemStyle: {
                                normal: {
                                    color: '#73D1F1',
                                    lineStyle: {
                                        width: 6,
                                    },
                                    opacity: 1
                                }
                            },
                        },
                        {
                            name: xldata[3],
                            data: yldata[3],
                            // data: [49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49],
                            type: 'line',
                           
                            smooth: false,
                            symbol: 'circle',
                            itemStyle: {
                                normal: {
                                    color: '#D2691E',
                                    lineStyle: {
                                        width: 6,
                                        type: 'dotted'
                                    },
                                    opacity: 1
                                }
                            },

                        },
                        {
                            name: xldata[4],
                            data: yldata[4],
                            // data: [49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49],
                            type: 'bar',
                           
                            smooth: false,
                            stack: '总量',
                            symbol: 'circle',
                            itemStyle: {
                                normal: {
                                    color: '#D2691E',
                                    lineStyle: {
                                        width: 6,
                                        type: 'dotted'
                                    },
                                    opacity: 1
                                }
                            },

                        },
                        {
                            name: xldata[5],
                            data: yldata[5],
                            type: 'line',
                           
                            smooth: false,
                            symbol: 'circle',
                            itemStyle: {
                                normal: {
                                    color: '#D2691E',
                                    lineStyle: {
                                        width: 6,
                                    },
                                    opacity: 1
                                }
                            },
                        },
                        {
                            name: xldata[6],
                            data: yldata[6],
                            // data: [49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49],
                            type: 'line',
                           
                            smooth: false,
                            symbol: 'circle',
                            itemStyle: {
                                normal: {
                                    color: '#FFA500',
                                    lineStyle: {
                                        width: 6,
                                        type: 'dotted'
                                    },
                                    opacity: 1
                                }
                            },

                        },
                        {
                            name: xldata[7],
                            data: yldata[7],
                            // data: [49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49],
                            type: 'bar',
                           
                            smooth: false,
                            stack: '总量',
                            symbol: 'circle',
                            itemStyle: {
                                normal: {
                                    color: '#FFA500',
                                    lineStyle: {
                                        width: 6,
                                        type: 'dotted'
                                    },
                                    opacity: 1
                                }
                            },

                        },
                        {
                            name: xldata[8],
                            data: yldata[8],
                            type: 'line',
                           
                            smooth: false,
                            symbol: 'circle',
                            itemStyle: {
                                normal: {
                                    color: '#FFA500',
                                    lineStyle: {
                                        width: 6,
                                    },
                                    opacity: 1
                                }
                            },
                        },
                        {
                            name: xldata[9],
                            data: yldata[9],
                            // data: [49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49],
                            type: 'line',
                           
                            smooth: false,
                            symbol: 'circle',
                            itemStyle: {
                                normal: {
                                    color: '#8A2BE2',
                                    lineStyle: {
                                        width: 6,
                                        type: 'dotted'
                                    },
                                    opacity: 1
                                }
                            },

                        },
                        {
                            name: xldata[10],
                            data: yldata[10],
                            // data: [49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49],
                            type: 'bar',
                           
                            smooth: false,
                            stack: '总量',
                            symbol: 'circle',
                            itemStyle: {
                                normal: {
                                    color: '#8A2BE2',
                                    lineStyle: {
                                        width: 6,
                                        type: 'dotted'
                                    },
                                    opacity: 1
                                }
                            },

                        },
                        {
                            name: xldata[11],
                            data: yldata[11],
                            type: 'line',
                           
                            smooth: false,
                            symbol: 'circle',
                            itemStyle: {
                                normal: {
                                    color: '#8A2BE2',
                                    lineStyle: {
                                        width: 6,
                                    },
                                    opacity: 1
                                }
                            },
                        },
                        {
                            name: xldata[12],
                            data: yldata[12],
                            // data: [49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49],
                            type: 'line',
                           
                            smooth: false,
                            symbol: 'circle',
                            itemStyle: {
                                normal: {
                                    color: '#13B60D',
                                    lineStyle: {
                                        width: 6,
                                        type: 'dotted'
                                    },
                                    opacity: 1
                                }
                            },

                        },
                        {
                            name: xldata[13],
                            data: yldata[13],
                            // data: [49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49],
                            type: 'bar',
                           
                            smooth: false,
                            stack: '总量',
                            symbol: 'circle',
                            itemStyle: {
                                normal: {
                                    color: '#13B60D',
                                    lineStyle: {
                                        width: 6,
                                        type: 'dotted'
                                    },
                                    opacity: 1
                                }
                            },

                        },
                        {
                            name: xldata[14],
                            data: yldata[14],
                            type: 'line',
                           
                            smooth: false,
                            symbol: 'circle',
                            itemStyle: {
                                normal: {
                                    color: '#13B60D',
                                    lineStyle: {
                                        width: 6,
                                    },
                                    opacity: 1
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