import { createRouter, createWebHistory } from "vue-router";

import Home from "@/views/Home.vue";

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: "/",
      redirect: { path: "/login" },
    },
    {
      path: "/home",
      name: "Home",
      component: Home,
      meta: { requiresAuth: true },
    },
    {
      path: "/login",
      name: "Login",
      component: () => import("@/views/Login.vue"),
    },
    {
      path: "/task/:groupId",
      name: "Task",
      component: () => import("@/views/Task.vue"),
      meta: { requiresAuth: true },
    },
    {
      path: "/profile",
      name: "Profile",
      component: () => import("@/views/Profile.vue"),
      meta: { requiresAuth: true },
    },
  ],
});

export default router;
