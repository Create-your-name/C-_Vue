/*import ocap from '@/view/o-cap.vue'*//*
import ListSelect from '@/view/ListSelect.vue'*/


const routes = [
    {
        path: '/',
        redirect: '/o-cap'
    },
    {
        name: "ocap",
        path: "/o-cap",
        component: () => import('@/view/o-cap.vue')
    },
    {
        name: '/Tab',
        path: '/Tab',
        component: () => import('@/view/TabInfo.vue'),
        props: (route) => ({
            tableData: route.query.tableData,
        })
    },
    {
        name: '/SPL_LOT',
        path: '/SPL_LOT',
        component: () => import('@/view/Table/ProInfo.vue'),
    },
    {
        name: '/WaferStart',
        path: '/WaferStart',
        component: () => import('@/view/Charts/WipChart.vue'),
    },
    {
        name: '/WaferOut',
        path: '/WaferOut',
        component: () => import('@/view/Charts/WipOut.vue'),
    },
     {
        name: '/StepMove',
        path: '/StepMove',
        component: () => import('@/view/Rep/WipMove.vue'),
    },
    {
        name: '/PcMonth',
        path: '/PcMonth',
        component: () => import('@/view/Month/PcMonth.vue'),
    },
    {
        name: '/FabHold',
        path: '/FabHold',
        component: () => import('@/view/Table/FabHold.vue'),
    },
    {
        name: '/1',
        path: '/1',
        component: () => import('@/view/Charts/Plan/WaferOutPlan.vue'),
    },
    {
        name: '/2',
        path: '/2',
        component: () => import('@/view/Charts/Plan/WaferStartPlan.vue'),
    },
    
];
export default routes
