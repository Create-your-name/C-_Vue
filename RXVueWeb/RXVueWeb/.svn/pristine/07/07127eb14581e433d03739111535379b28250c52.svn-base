
<template>

    <el-button type="success"  :plain="true" @click="SendEmail">Success</el-button>

</template>

<style>
    /*     style 加上 scoped  指的是 给本页面中的所有控件 加上一个范围 scoped 中  会给本页面中每个组件生成一个统一的ID 来区分
                                                                                      如果 传递了子组件进来 则给子组件一样赋值这个统一ID
                                                                                      (前提是子组件根组件唯一)


                                                                                                                  console.log(row.pid);
                                                                                                                  console.log(row.tid);

                                                ：deep(组件){}     深度选择器
                                                ：global(组件)     全局选择器

                                                ：class="$style.类名"  可以指定他 的style 使用
         */

</style>
<script>
    import { ElMessage } from 'element-plus'
    import axios from "axios";
    export default {
                data() {
                  return {

                  }
                },
                methods: {

                    SendEmail(){
                             ElMessage({
                                    message: 'Congrats, this is a success message.',
                                    type: 'success',
                          });
                           axios
                                .get("https://localhost:7155/api/Email/Sendmail")
                    }

                },
                mounted() {
      
                }
              }
                   
</script>

