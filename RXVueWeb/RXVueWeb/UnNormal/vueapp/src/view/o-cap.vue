﻿ <template>
     <el-form :model="form" label-width="120px" :rules="rules">
         <el-tabs type="card" class="demo-tabs">

             <el-tab-pane label="总异常剔片报表" name="first">
                 <el-divider>
                     <el-icon>
                         <HomeFilled />
                     </el-icon>
                 </el-divider>
                 <el-row>
                     <el-col :span="12">
                         <el-form-item label="异常单填写日期" required style="width:800px">
                             <el-row>
                                 <el-col :span="11">
                                     <el-form-item prop="activityBeginTime">
                                         <el-date-picker type="datetime" placeholder="开始时间" v-model="form.activityBeginTime" style="width: 150%;"
                                                         :editable="false" value-format="YYYY-MM-DD HH:mm:ss"></el-date-picker>
                                     </el-form-item>
                                 </el-col>
                                 <el-col :span="2" style="text-align: center;">至</el-col>
                                 <el-col :span="11">
                                     <el-form-item prop="activityEndTime">
                                         <el-date-picker type="datetime" placeholder="结束时间" v-model="form.activityEndTime" style="width: 150%;"
                                                         :editable="false" value-format="YYYY-MM-DD HH:mm:ss"></el-date-picker>
                                     </el-form-item>
                                 </el-col>
                             </el-row>
                         </el-form-item>
                     </el-col>
                     <el-col :span="12">
                         <el-form-item label="异常单完成日期" required style="width:800px">
                             <el-row>
                                 <el-col :span="11">
                                     <el-form-item prop="activityBeginTime2">
                                         <el-date-picker type="datetime" placeholder="开始时间" v-model="form.activityBeginTime2" style="width: 150%;"
                                                         :editable="false" value-format="YYYY-MM-DD HH:mm:ss"></el-date-picker>
                                     </el-form-item>
                                 </el-col>
                                 <el-col :span="2" style="text-align: center;">至</el-col>
                                 <el-col :span="11">
                                     <el-form-item prop="activityEndTime2">
                                         <el-date-picker type="datetime" placeholder="结束时间" v-model="form.activityEndTime2" style="width: 150%;"
                                                         :editable="false" value-format="YYYY-MM-DD HH:mm:ss"></el-date-picker>
                                     </el-form-item>
                                 </el-col>
                             </el-row>
                         </el-form-item>
                     </el-col>
                 </el-row>


                 <el-row class="row-bg" justify="space-evenly">
                     <el-col :span="12">
                         <el-form-item label="异常单号" prop="f_Yc_Odd">
                             <el-input v-model="form.f_Yc_Odd" style="width:200px" />
                             <el-select v-model="form.f_Yc_Odd" clearable class="filter-item" placeholder="输入您所需的异常单号">
                                 <el-option v-for="item in uniqueKey(tableData,'no')" :key="item.no" :label="item.no" :value="item.no" />
                             </el-select>
                         </el-form-item>
                     </el-col>
                     <el-col :span="12">
                         <el-form-item label="批号" prop="f_LOT">
                             <el-input v-model="form.f_LOT" style="width:200px" />
                             <el-select v-model="form.f_LOT" clearable placeholder="输入您所需的批号">
                                 <el-option v-for="item in uniqueKey(tableData,'ph')" :key="item.ph" :label="item.ph" :value="item.ph" />

                             </el-select>
                         </el-form-item>
                     </el-col>
                 </el-row>

                 <el-row class="row-bg" justify="space-evenly">
                     <el-col :span="4">
                         <el-form-item label="工    艺" prop="f_Pro">
                             <el-select v-model="form.f_Pro" clearable placeholder="输入您所需的工艺名称">
                                 <el-option v-for="item in uniqueKey(tableData,'gy')" :key="item.gy" :label="item.gy"
                                            :value="item.gy" />

                             </el-select>
                         </el-form-item>
                     </el-col>
                     <el-col :span="5">
                         <el-form-item label="Equip ID" prop="f_Equip_ID">
                             <el-select v-model="form.f_Equip_ID" clearable placeholder="输入您所需的设备名称">
                                 <el-option v-for="item in uniqueKey(tableData,'equipid')" :key="item.equipid" :label="item.equipid"
                                            :value="item.equipid" />
                             </el-select>
                         </el-form-item>
                     </el-col>
                     <el-col :span="5">
                         <el-form-item label="工程师确认部门" prop="f_OP_Depart">
                             <el-select v-model="form.f_OP_Depart" clearable placeholder="输入您所需的部门名称">
                                 <el-option v-for="item in uniqueKey(tableData,'ycclBm')" :key="item.ycclBm" :label="item.ycclBm"
                                            :value="item.ycclBm" />
                             </el-select>
                         </el-form-item>
                     </el-col>
                     <el-col :span="5">
                         <el-form-item label="工艺大类" prop="f_Pro_Kind">
                             <el-select v-model="form.f_Pro_Kind" clearable placeholder="输入您所需的工艺大类">
                                 <el-option v-for="item in uniqueKey(tableData,'gy')" :key="item.gy" :label="item.gy"
                                            :value="item.gy" />
                             </el-select>
                         </el-form-item>
                     </el-col>
                     <el-col :span="5">
                         <el-form-item label="责任部门一" prop="f_Res_Depart">
                             <el-select v-model="form.f_Res_Depart" clearable placeholder="输入所对应的责任部门一">
                                 <el-option v-for="item in uniqueKey(tableData,'zrbm1')" :key="item.zrbm1" :label="item.zrbm1"
                                            :value="item.zrbm1" />
                             </el-select>
                         </el-form-item>
                     </el-col>
                 </el-row>

                 <el-row class="row-bg" justify="space-evenly">
                     <el-col :span="4">
                         <el-form-item label="工程师确认现象" prop="f_OP_Pheno">
                             <el-select v-model="form.f_OP_Pheno" clearable placeholder="请确认现象 ">
                                 <el-option v-for="item in uniqueKey(tableData,'ycxxqr')" :key="item.ycxxqr" :label="item.ycxxqr"
                                            :value="item.ycxxqr" />
                             </el-select>
                         </el-form-item>
                     </el-col>
                     <el-col :span="5">
                         <el-form-item label="产品名称" prop="f_Product_name">
                             <el-select v-model="form.f_Product_name" clearable placeholder="请输入产品名称">
                                 <el-option v-for="item in uniqueKey(tableData,'cppz')" :key="item.cppz" :label="item.cppz"
                                            :value="item.cppz" />
                             </el-select>
                         </el-form-item>
                     </el-col>
                     <el-col :span="5">
                         <el-form-item label="工程师确认层次" prop="f_OP_Level">
                             <el-select v-model="form.f_OP_Level" clearable placeholder="请确认层次">
                                 <el-option v-for="item in uniqueKey(tableData,'ycclcc')" :key="item.ycclcc" :label="item.ycclcc"
                                            :value="item.ycclcc" />
                             </el-select>
                         </el-form-item>
                     </el-col>
                     <el-col :span="5">
                         <el-form-item label="确认意见" prop="f_Idea">
                             <el-select v-model="form.f_Idea" clearable placeholder="请输入您的意见">
                                 <el-option v-for="item in uniqueKey(tableData,'cpownerQryj')" :key="item.cpownerQryj" :label="item.cpownerQryj"
                                            :value="item.cpownerQryj" />
                             </el-select>
                         </el-form-item>
                     </el-col>
                     <el-col :span="5">
                         <el-form-item label="责任部门二" prop="f_Res_Depart_2">
                             <el-select v-model="form.f_Res_Depart_2" clearable placeholder="请输入责任部门二">
                                 <el-option v-for="item in uniqueKey(tableData,'zrbm2')" :key="item.zrbm2" :label="item.zrbm2"
                                            :value="item.zrbm2" />
                             </el-select>
                         </el-form-item>
                     </el-col>
                 </el-row>


                 <el-row class="row-bg" justify="space-evenly">
                     <el-col :span="8">
                         <el-form-item label="异常原因归类" prop="f_Cause_Range">
                             <el-select v-model="form.f_Cause_Range" clearable placeholder="请选择异常原因">
                                 <el-option v-for="item in uniqueKey(tableData,'ycyygl')" :key="item.ycyygl" :label="item.ycyygl"
                                            :value="item.ycyygl" />
                             </el-select>
                         </el-form-item>
                     </el-col>
                     <el-col :span="8">
                         <!--   @change="getDataList()" @clear="getDataList()" @focus="get_OP_Class"-->
                         <el-form-item label="工程师确认分类" prop="f_OP_Class">
                             <el-select v-model="form.f_OP_Class" clearable placeholder="请确认分类">
                                 <el-option v-for="item in uniqueKey(tableData,'ycclFl')" :key="item.ycclFl" :label="item.ycclFl"
                                            :value="item.ycclFl" />
                             </el-select>
                         </el-form-item>
                     </el-col>

                 </el-row>

                 <!--         <el-form-item label="当前状态" prop="status">
        <el-checkbox-group v-model="form.status">
            <el-radio v-model="form.status" label="1">工程师确认</el-radio>
            <el-radio v-model="form.status" label="2">主管确认</el-radio>
            <el-radio v-model="form.status" label="3">产品OWNER处理</el-radio>
            <el-radio v-model="form.status" label="4">同意处置结束</el-radio>
            <el-radio v-model="form.status" label="5">重新处置结束</el-radio>
        </el-checkbox-group>
    </el-form-item>-->
                 <!--<el-form-item label="请选择查询栏位">
        <el-button type="primary">
            <router-link to="/ListSelect">选择 </router-link>
        </el-button>
    </el-form-item>

    <el-form-item label="排序">
        <el-text class="mx-1" type="danger" style="margin-left:50px">第一顺序</el-text>
        <el-select v-model="form.region" placeholder="第一顺序">
            <el-option label="Zone one" value="shanghai" />
            <el-option label="Zone two" value="beijing" />
        </el-select>
        <el-text class="mx-1" type="primary" style="margin-left:50px">第二顺序</el-text>
        <el-select v-model="form.region2" placeholder="第二顺序">
            <el-option label="Zone one" value="shanghai" />
            <el-option label="Zone two" value="beijing" />
        </el-select>
    </el-form-item>-->

                 <el-button type="primary" @click="getDataList()"> 查询</el-button>
                 <TabTest :table="formData" :tableLabel="tableLabel" :Tid="tableID" :total="total" @updateNum="updateNum" :headerCellStyle="headerCellStyle" :rowStyle="rowStyle" :cellStyle="cellStyle"></TabTest>
                 <!--      <el-button @click="saveForm('ruleForm')"> 查询</el-button>-->
                 <!--<el-table :data="formData" id="tableId" border style="width: 100% ; font-size: 5px" height="900" :row-style="{background:'#AFEEEE',height:5+'px'}"
              :header-cell-style="{background:'#9ACD32',height:'250',color:'#000000',border: '1px solid tan'}" v-horizontal-scroll="'always'">
        <el-table-column fixed="left" prop="ph" label="批号" width="100" />
        <el-table-column fixed="left" prop="no" label="TASKID" width="180" />
        <el-table-column prop="cppz" label="产品总类" width="150" />
        <el-table-column label="ABNORM CARD" width="150" />
        <el-table-column prop="recipeid" label="RecipeID" width="100" />
        <el-table-column prop="lps" label="来片数" width="100" />
        <el-table-column prop="kyps" label="可疑片数" width="100" />
        <el-table-column prop="gy" label="工艺" width="150" />
        <el-table-column prop="lottype" label="LOTTYPE" width="100" />
        <el-table-column prop="location" label="LOCATION" width="100" />
        <el-table-column prop="stage" label="STAGE" width="100" />
        <el-table-column prop="equipid" label="EQUIP ID" width="100" />
        <el-table-column prop="cpowner" label="产品OWNER" width="100" />
        <el-table-column prop="zxyc" label="异常现象" width="150" />
        <el-table-column prop="clbm" label="处理部门" width="100" />
        <el-table-column prop="tzgcs" label="通知工程师" width="100" />
        <el-table-column prop="xxms" label="现象描述" width="2700" />
        <el-table-column prop="applyDate" label="发现日期" width="200" />
        <el-table-column prop="applyName" label="发现人" width="100" />
        <el-table-column prop="ycclBm" label="异常部门" width="100" />
        <el-table-column prop="ycclXz" label="异常现象" width="150" />
        <el-table-column prop="ycclFl" label="异常分类" width="100" />
        <el-table-column prop="ycclcc" label="异常层次" width="100" />
        <el-table-column prop="yocap" label="有无OCAP" width="100" />
        <el-table-column prop="ycms" label="工程师对异常的描述" width="2700" />
        <el-table-column prop="ycxxqr" label="工程师确认的异常现象" width="200" />
        <el-table-column prop="ycyygl" label="异常原因归类" width="100" />
        <el-table-column prop="cbyyfx" label="初步原因分析" width="800" />
        <el-table-column prop="ycid" label="异常EQUIPID" width="150" />
        <el-table-column prop="ycms" label="设备/菜单临时措施" width="2700" />
        <el-table-column prop="sftzowner" label="是否通知产品OWNER/FMA" width="300" />
        <el-table-column prop="c1" label="工程师异常放行" width="150" />
        <el-table-column prop="c2" label="工程师返工" width="150" />
        <el-table-column prop="c3" label="工程师报废" width="150" />
        <el-table-column prop="c4" label="工程师正常放行" width="150" />
        <el-table-column prop="ycclgcs" label="处理工程师" width="100" />
        <el-table-column prop="ycqrQrzgQrrq" label="处理日期" width="100" />
        <el-table-column prop="cpownerQryj" label="确认意见" width="500" />
        <el-table-column prop="cpownerYcdj" label="异常等级" width="100" />
        <el-table-column prop="z1" label="再处理异常放行" width="150" />
        <el-table-column prop="z2" label="再处理返工" width="150" />
        <el-table-column prop="z3" label="再处理在处理报废" width="150" />
        <el-table-column prop="z4" label="再处理正常放行" width="150" />
        <el-table-column prop="cpowmerQzyx" label="产品潜在影响" width="100" />
        <el-table-column prop="cpownerSfxyzrbmyyfx" label="是否需要责任部门原因分析" width="200" />
        <el-table-column prop="cpownerSfkmrb" label="是否开MRB" width="100" />
        <el-table-column prop="cponwerName" label="确认工程师" width="100" />
        <el-table-column prop="cpownerRq" label="确认日期" width="100" />
        <el-table-column label="表单状态" width="100" />
        <el-table-column label="是否挂起" width="100" />
        <el-table-column label="被谁拒绝" width="100" />
        <el-table-column label="过程" width="100" />
        <el-table-column prop="location" label="责任部门一" width="100" />
        <el-table-column prop="c1" label="报废" width="100" />
        <el-table-column prop="c2" label="返工" width="100" />
        <el-table-column prop="c3" label="异常放行" width="100" />
        <el-table-column prop="c4" label="正常放行" width="100" />
        <el-table-column label="原因六大类" width="100" />
        <el-table-column prop="ycclBm" label="责任部门二" width="100" />
        <el-table-column prop="z1" label="报废" width="100" />
        <el-table-column prop="z2" label="返工" width="100" />
        <el-table-column prop="z3" label="异常放行" width="100" />
        <el-table-column prop="z4" label="正常放行" width="100" />
        <el-table-column label="原因六大类" width="100" />
        <el-table-column label="备注" width="100" />
    </el-table>-->
                 <!--                <TableInfo :tableData="formData" />-->
                 <!--                <TableInfo :tableData="formData" v-show="dialog_visible" >查询</TableInfo>-->
             </el-tab-pane>


             <el-tab-pane label="异常责任部门报表" name="second" class="UserTable" >
                 <TableInfo></TableInfo>
                 <!--<TableInfo :tableData="tableData"        从o-cap 父组件 传递给 TableInfo 组件 的props 对象 名为 tableData的 为本组件的 tableData值    />-->
                 <!--                <router-link to="Tab">异常责任部门报表显示</router-link>



    -->
             </el-tab-pane>

             <!-- router.push(
            {
                path: '/Tab',
                query: {
                    tableData: this.formData
                }
                    import router from "@/router/index"
            }
        )-->
         </el-tabs>




         <!--   FormInfo() {
    router.push(
    {
    path: '/Tab',
    query: {
    tableData: this.form

    { label: 'ABNORM CARD', width: '150', prop: 'url', show: true, },
                {
                    prop: 'Protect', label: '是否设防', isok: '1', formatData: function (val) {
                        return val == true ? '设防' : '未设防'
                    }
                },

    }
    }
    )
    },-->


     </el-form>
    <!--   <button @click="getValue()">获取</button>-->

    <!--         this.$router.push({ name: "/Tab", query: { Data:JSON.stringify(this.formData)} })    "    路由push传递参数  -->
</template>

<script>
    import axios from "axios";
    import TableInfo from "./TabInfo.vue"
    import img from '@/assets/rxlogo.jpg'
    import TabTest from "./TabTest.vue"

    // do not use same name with ref

    //  _YC_DataFill: "", // 异常单填写时间

    //  _YC_AcomData: "", //异常单完成时间                        f_YC_DataFill: [], // 异常单填写时间


            

    export default {
        components: {
            TableInfo,
            TabTest
        },
        data() {
            var validateEventEnd = (rule, value, callback) => {
                if (value < this.form.activityBeginTime) {
                    callback(new Error("结束时间需晚于开始时间!"));
                } else {
                    callback();
                }
            };
            var validateEventEnd2 = (rule, value, callback) => {
                if (value < this.form.activityBeginTime2) {
                    callback(new Error("结束时间需晚于开始时间!"));
                } else {
                    callback();
                }
            };
            return {
                tableID: 'T1',
                total: 1000,
                headerCellStyle: {
                background: '#9ACD32', height: '250', color: '#000000', border: '1px solid tan', 'text-align': 'center'
                },
                rowStyle: {
                background: '#AFEEEE', height: 5 + 'px', 'text-align': 'center'
                },
                cellStyle: {
                'text-align': 'center'
                },
                form: {
                    f_Yc_Odd: "", //异常单号
                    f_LOT: "", //批号             4
                    f_Pro: "", //工艺
                    f_Equip_ID: "", //设备ID      2
                    f_OP_Depart: "", //工程师确认部门
                    f_Pro_Kind: "", //工艺大类
                    f_Res_Depart: "", //责任部门1
                    f_OP_Pheno: "", //工程师确认现象
                    f_Product_name: "", //产品名称
                    f_Res_Depart_2: "", //责任部门2
                    f_OP_Level: "", //工程师确认层次
                    f_Idea: "", //意见        3
                    f_Cause_Range: "", //异常原因归类 1
                    f_OP_Class: "", //工程师确认分类
                    f_bf_NoNull: "", //     报废非0
                    status: "",         //当前状态
                    region: "",  //排序1
                    region2: "", //排序2
                    f_ReHu: "",
                    activityBeginTime: "",   //异常单填写时间1
                    activityEndTime: "",    //异常单填写时间2

                activityBeginTime2: "",   //异常单完成时间1
                activityEndTime2: "",    //异常单完成时间2
                },
                imgUrl: img,
                tableData: [],
                formData: [],
                    tableLabel: [
                {  label: '批号', width: '150', prop: 'ph', show: true  },

                { label: 'ABNORM CARD' ,width:'200',url1:true },

                { label: 'TASKID', width: '180', prop: 'no', show: true },
                { label: '产品总类', width: '150', prop: 'cppz', show: true },
                { label: 'RecipeID', width: '150', prop: 'recipeid', show: true },
                { label: '来片数', width: '150', prop: 'lps', show: true },
                { label: '可疑片数', width: '150', prop: 'kyps', show: true },
                { label: '工艺', width: '150', prop: 'gy', show: true },
                { label: 'LOTTYPE', width: '100', prop: 'lottype', show: true },
                { label: 'LOCATION', width: '150', prop: 'location', show: true },
                { label: 'STAGE', width: '100', prop: 'stage', show: true },
                { label: 'EQUIP ID', width: '150', prop: 'equipid', show: true },
                { label: '产品OWNER', width: '150', prop: 'cpowner', show: true },
                { label: '异常现象', width: '150', prop: 'zxyc', show: true },
                { label: '处理部门', width: '150', prop: 'clbm', show: true },
                { label: '通知工程师', width: '150', prop: 'tzgcs', show: true },
                { label: '现象描述', width: '600', prop: 'xxms', show: true },
                { label: '发现日期', width: '200', prop: 'applyDate', show: true },
                { label: '发现人', width: '100', prop: 'applyName', show: true },
                { label: '异常部门', width: '100', prop: 'ycclBm', show: true },
                { label: '异常现象', width: '150', prop: 'ycclXz', show: true },
                { label: '异常分类', width: '100', prop: 'ycclFl', show: true },
                { label: '异常层次', width: '100', prop: 'ycclcc', show: true },
                { label: '有无OCAP', width: '150', prop: 'yocap', show: true },
                { label: '工程师对异常的描述', width: '600', prop: 'ycms', show: true },
                { label: '工程师确认的异常现象', width: '200', prop: 'ycxxqr', show: true },
                { label: '异常原因归类', width: '150', prop: 'ycyygl', show: true },
                { label: '初步原因分析', width: '800', prop: 'cbyyfx', show: true },
                { label: '异常EQUIPID', width: '150', prop: 'ycid', show: true },
                { label: '工程师意见', width: '600', prop: 'gcsyj', show: true },
                { label: '设备/菜单临时措施', width: '600', prop: 'ycclLscs', show: true },
                { label: '是否通知产品OWNER/FMA', width: '300', prop: 'sftzowner', show: true },
                { label: '工程师异常放行', width: '150', prop: 'c1', show: true },
                { label: '工程师返工', width: '150', prop: 'c2', show: true },
                { label: '工程师报废', width: '150', prop: 'c3', show: true },
                { label: '工程师正常放行', width: '150', prop: 'c4', show: true },
                { label: '处理工程师', width: '120', prop: 'ycclgcs', show: true },
                { label: '处理日期', width: '100', prop: 'ycqrQrzgQrrq', show: true },
                { label: '确认意见', width: '500', prop: 'cpownerQryj', show: true },
                { label: '异常等级', width: '100', prop: 'cpownerYcdj', show: true },
                { label: '再处理异常放行', width: '150', prop: 'z1', show: true },
                { label: '再处理返工', width: '150', prop: 'z2', show: true },
                { label: '再处理在处理报废', width: '150', prop: 'z3', show: true },
                { label: '再处理正常放行', width: '150', prop: 'z4', show: true },
                { label: '产品潜在影响', width: '150', prop: 'yield', show: true },
                { label: '是否需要责任部门原因分析', width: '200', prop: 'cpownerSfxyzrbmyyfx', show: true },
                { label: '是否开MRB', width: '150', prop: 'cpownerSfkmrb', show: true },
                { label: '确认工程师', width: '150', prop: 'cponwerName', show: true },
                { label: '确认日期', width: '200', prop: 'cpownerRq', show: true },
               
                { label: '表单状态', width: '100',prop:'name', show: true },
                { label: '是否挂起', width: '100',  show: true },
                { label: '被谁拒绝', width: '100', show: true },

                { label: '过程', width: '100', url2: true },

                { label: '责任部门一', width: '150', prop: 'zrbm1', show: true },
                { label: '报废', width: '100', prop: 'zrbm1Bf', show: true },
                { label: '返工', width: '100', prop: 'zrbm1Fg', show: true },
                { label: '异常放行', width: '100', prop: 'zrbm1Ycfx', show: true },
                { label: '正常放行', width: '100', prop: 'zrbm1Zcfx', show: true },
                { label: '原因六大类', width: '150', prop: 'zrbm1Yyldl', show: true },
                { label: '责任部门二', width: '150', prop: 'zrbm2', show: true },
                { label: '报废', width: '100', prop: 'zrbm2Bf', show: true },
                { label: '返工', width: '100', prop: 'zrbm2Fg', show: true },
                { label: '异常放行', width: '100', prop: 'zrbm2Ycfx', show: true },
                { label: '正常放行', width: '100', prop: 'zrbm2Zcfx', show: true },
                { label: '原因六大类', width: '150', prop: 'zrbm2Yyldl', show: true },
                { label: '备注', width: '150', show: true }
                    ],
            rules: {
                activityEndTime: [{
                    validator: validateEventEnd,
                    trigger: "change"
                }],
                activityEndTime2: [{
                    validator: validateEventEnd2,
                    trigger: "change"
                }],
            }
            };
        },
    methods: {
        updateNum(num) {
            this.tableLabel = num;
        },
            changeTime() {
                this.$forceUpdate();
            },
          onRadioChange(e, i) {
                console.log(e.target.tagName);
                if (e.target.tagName === "INPUT") {
                    if (this.form.f_ReHu === "") {
                        this.form.f_ReHu = i;
                    } else {
                        this.form.f_ReHu = "";
                    }
                }
                console.log(123);
            },
            onRadioChange2(e, i) {
                console.log(e.target.tagName);
                if (e.target.tagName === "INPUT") {
                    if (this.form.f_bf_NoNull === "") {
                        this.form.f_bf_NoNull = i;
                    } else {
                        this.form.f_bf_NoNull = "";
                    }
                }
                console.log(123);
            },
                getDataList() {
                //    axios.post("https://localhost:7155/api/DepartMent/Lot", this.form)
                    axios.post("http://10.163.76.23/api/api/DepartMent/Lot", this.form)
                        .then((res) => {
                            this.formData = res.data;
                            this.total = res.data.length;
                        }).catch(err => {
                            console.log(err)
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
                QueryDepartList() {
                    axios
                    //    .get("https://localhost:7155/api/DepartMent")
                        .get("http://10.163.76.23/api/api/DepartMent")
                        .then((res) => {
                            this.tableData = res.data;
                        })
                },
            getValue() {

            }
        },
        mounted() {
         	this.QueryDepartList();
	        document.title = "异常单查询"
        },
    };
</script>


<style lang="less">

    .el-table__body .el-table__row.hover-row td {
        background-color: #FFFACD !important;
    }

</style>