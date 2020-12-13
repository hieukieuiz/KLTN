import '@babel/polyfill'
import Vue from 'vue';
import '@mdi/font/css/materialdesignicons.css'
import Vuetify from 'vuetify';
require('@/plugins/vuetify');
import 'vuetify/dist/vuetify.min.css';
import App from './App.vue';
import router from './router';
import store from './store/store';
//import './registerServiceWorker';
import VeeValidate, { Validator } from "vee-validate";
import Snotify from 'vue-snotify'
import { SnotifyService } from 'vue-snotify/SnotifyService';
import "vue-snotify/styles/material.css";
import * as moment from 'moment';
import EventBus from '@/EventBus';
import DateTimePicker from '@/components/Commons/DateTimePicker';
import VChooseFile from '@/components/Commons/VChooseFile';
import VueCkeditor from '@/components/Commons/VueCkeditor';
import CommonFunction, { CommonFunctionsService } from '@/Utils/CommonFunctions';


require('moment/locale/vi');
Vue.use(require('vue-moment'), {
    moment
});

Vue.use(DateTimePicker);
Vue.use(VueCkeditor);
Vue.use(VChooseFile);
Vue.use(Snotify);
Vue.use(EventBus);
Vue.use(VeeValidate, {events: 'blur'});
Validator.localize('vi', require('vee-validate/dist/locale/vi'));
Vue.use(CommonFunction);

Vue.config.productionTip = true;
declare module 'vue/types/vue' {
    interface Vue {
        $snotify: SnotifyService,
        $moment: any,
        $validator: Validator,
        $eventBus: Vue,
        $commonFunctions: CommonFunctionsService
    }
}
const opts = {
    dark: true,
    icons: {
        iconfont: 'mdi',
    },
} as any
Vue.use(Vuetify);
new Vue({
    vuetify: new Vuetify(opts),
    router,
    store,
    render: (h) => h(App),
}).$mount('#app');
