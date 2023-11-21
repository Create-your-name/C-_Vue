<template>
    <div id="barStacked"
         style="width: 100%;
        height: 270px;margin-bottom: 20px;background:rgba(236, 242, 254, 1);">
    </div>
</template>
<script>
    import { defineComponent, onMounted } from "vue";
    import * as echarts from 'echarts';
    export default defineComponent({
        name: 'duidie-bar',
        setup() {
            const options = {
                tooltip: {
                    trigger: 'axis',
                    axisPointer: {
                        type: 'shadow', 
                    },
                },
                legend: {
                    show:true,
                },
                grid: {
                    left: '3%',
                    right: '4%',
                    bottom: '3%',
                    containLabel: true,
                },
                xAxis: [
                
                    {
                        type: 'category',
                        data: ['周一', '周二', '周三', '周四', '周五', '周六', '周日'],
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
                            fontSize: 12,
                        },
                    },
                ],
                yAxis: [
                    {
                        type: 'value',
                        name: '单位：家',
                        nameTextStyle: {
                            color: 'rgba(0, 0, 0, 0.6)',
                            fontSize: 12,
                        },
                        axisLine: {
                            show: true,
                            lineStyle: {
                                color: '#D5DDE7',
                            },
                        },
                        axisLabel: {
                            color: 'rgba(0, 0, 0, 0.85)',
                            fontSize: 12,
                        },
                    },
                ],
                series: [
                    {
                        name: '腾讯',
                        data:[820,932,901,1290,1180,1060],
                        type:'line'
                    },
                    {
                        name: '幼儿园',
                        type: 'bar',
                        stack: 'email',
                        barWidth: 14,
                        itemStyle: { // 自定义柱子颜色
                            normal: { color: '#F36D78' },
                        },
                        emphasis: {
                            focus: 'series',
                        },
                        data: [120, 132, 101, 134, 90, 130, 210],
                    },
                    {
                        name: '小学',
                        type: 'bar',
                        stack: 'email',
                        barWidth: 14,
                        itemStyle: { // 自定义柱子颜色
                            normal: { color: '#85DBBE' },
                        },
                        emphasis: {
                            focus: 'series',
                        },
                        data: [220, 182, 191, 234, 290, 130, 310],
                    }, {
                        name: '初中',
                        type: 'bar',
                        stack: 'email',
                        barWidth: 14,
                        itemStyle: { // 自定义柱子颜色
                            normal: { color: '#4787F0' },
                        },
                        emphasis: {
                            focus: 'series',
                        },
                        data: [220, 182, 191, 234, 290, 130, 310],
                    }, {
                        name: '高中',
                        type: 'bar',
                        stack: 'email',
                        barWidth: 14,
                        itemStyle: { // 自定义柱子颜色
                            normal: { color: '#ED7B2F' },
                        },
                        emphasis: {
                            focus: 'series',
                        },
                        data: [220, 182, 191, 234, 290, 130, 310],
                    }, {
                        name: '大学',
                        type: 'bar',
                        stack: 'email',
                        barWidth: 14,
                        itemStyle: { // 自定义柱子颜色
                            normal: { color: 'rgba(0, 0, 0, 0.4)' },
                        },
                        emphasis: {
                            focus: 'series',
                        },
                        data: [220, 182, 191, 234, 290, 130, 310],
                    },
                ],
            };
            onMounted(() => {
                // 堆叠柱状图-情况一
                const barStacked = document.getElementById('barStacked');
                const myecharts = echarts.init(barStacked);
                myecharts.setOption(options);
            })
            return {
            }
        }
    })
</script>