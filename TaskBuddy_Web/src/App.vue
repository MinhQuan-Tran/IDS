<script lang="ts">
import Header from "@/components/Header.vue";

export default {
  components: {
    Header,
  },
  data() {
    return {
      taskName: "TaskBuddy"
    }
  },
  computed: {
    pageName() {
      if (this.$route.name === "Task") {
        return this.taskName;
      }
      return this.$route.name;
    }
  },
  mounted() {
  }
};
</script>

<template>
  <Header v-if="!(pageName === 'Login')">{{ pageName }}</Header>
  <router-view class="router-view" @pageName="(name: string) => taskName = name"></router-view>
</template>

<style scoped>
.router-view {
  height: 100%;
}

@media (prefers-color-scheme: dark) {
  .router-view {
    background-color: var(--dark-background);
  }
}
</style>
