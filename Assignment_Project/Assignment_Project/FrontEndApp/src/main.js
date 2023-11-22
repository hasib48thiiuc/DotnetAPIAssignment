import axios from 'axios';

axios.defaults.baseURL = 'http://localhost:5000/api'; // Change to your API endpoint

Vue.prototype.$http = axios;


import { createApp } from 'vue'
import App from './App.vue'

createApp(App).mount('#app')
