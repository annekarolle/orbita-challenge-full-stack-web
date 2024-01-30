 import { createRouter, createWebHistory } from 'vue-router';
import Home from '../pages/home-page/home-page.vue';
import Dashboard from '../pages/dash-board/dash-board.vue';
import StudentsCrudVue from '@/components/StudentsCrud/StudentsCrud.vue';
import StudentsListVue from '@/components/StudentsList/StudentsList.vue';

const routes = [
  {
    path: '/',
    component: Home,
  },
  {
    path: '/dashboard',
    component: Dashboard,
    children: [
      {
        path: 'cadastrar',  
        component: StudentsCrudVue,  
      },
      {
        path: 'listar',  
        component: StudentsListVue,  
      },
    ],
    // meta: {
    //   requiresAuth: true,
    // },
  },
];

const router = createRouter({
  history: createWebHistory(""), 
  routes,
});

router.beforeEach((to, from, next) => {
    if (to.path !== '/' && !isAuthenticated()) {
      next({ path: '/' });
    } else {
      next();
    }
  });

  function isAuthenticated() {
    // Implementação da lógica de autenticação
    // Retorne true se o usuário estiver autenticado, false caso contrário
    return true; // Adapte conforme necessário
  }


export default router

 