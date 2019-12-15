import Vue from 'vue';
import axios from 'axios';
import router from './router/index';
import store from './store';
import { sync } from 'vuex-router-sync';
import App from 'components/root/app-root';
import { FontAwesomeIcon } from './icons';
import PageHead from 'components/shared/page-head';
import Notifications from 'vue-notification';
import Search from 'components/shared/search';
import CSSIText from 'components/Input/text';
import VueContentPlaceholders from 'vue-content-placeholders';


// Registration of global components
Vue.component('icon', FontAwesomeIcon);
Vue.component('page-head', PageHead);
Vue.component('search', Search);
Vue.use(Notifications);
Vue.use(VueContentPlaceholders);
//Registration for Inputs Controls 
Vue.component('cssi-text', CSSIText);
Vue.prototype.$http = axios

sync(store, router)

const app = new Vue({
  store,
  router,
  ...App
})

export {
  app,
  router,
  store
}
