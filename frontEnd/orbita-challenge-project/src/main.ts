import './assets/main.css';
import { createApp } from 'vue';
import App from './App.vue';
import router from './routes/router';
import '@mdi/font/css/materialdesignicons.css';
import 'vuetify/styles';
import { createVuetify } from 'vuetify';
 
 

 
const vuetify = createVuetify({ 
});
 
const app = createApp(App);
 
app
  .use(router)
  .use(vuetify) 
  .mount('#app');  
  
export default vuetify;