<script lang="ts">
export default {
  data() {
    return {
      taskGroup: [
        {
          id: 1,
          name: "Task Group 1",
          members: [
            "Member 1",
            "Member 2",
            "Member 3",
          ]
        },
        {
          id: 2,
          name: "Task Group 2",
          members: [
            "Member 4",
            "Member 5",
          ]
        }
      ],
    };
  },
  methods: {
    displayGroupMembers(members: string[]) {
      return members.join(", ");
    }
  }
}
</script>

<template>
  <div class="home">
    <div class="greeting">
      <span>
        Welcome to TaskBuddy!
      </span>
      <span class="username">
        <slot>Please login or register to continue.</slot>
      </span>
    </div>

    <main>
      <div v-if="!taskGroup.length">
        <span>
          Welcome to Task Buddy! <br>
          <br>
          Click the button below to create or join a task list.
        </span>
      </div>
      <router-link v-else v-for="group in  taskGroup " :to="{ name: 'Task', params: { groupId: group.id } }"
        class="group-card">
        <span class="group-name">{{ group.name }}</span>
        <br>
        <span class="group-members">{{ displayGroupMembers(group.members) }}</span>
      </router-link>
    </main>
  </div>
</template>

<style scoped>
.home {
  display: flex;
  flex-direction: column;
  justify-content: flex-start;
  align-items: center;
  gap: 10px;
  min-height: 100%;
  padding: 15px;
  background: url(../assets/background.jpg) no-repeat center center fixed;
  background-size: cover;
}

.greeting {
  align-self: flex-start;
  text-align: left;
  color: white;
  display: flex;
  flex-direction: column;
  align-items: flex-start;
  font-size: 1.25em;
}

.username {
  font-weight: bold;
}

main {
  box-sizing: border-box;
  width: 100%;
  display: flex;
  flex-direction: column;
  justify-content: flex-start;
  align-items: center;
  gap: 10px;
}

main>* {
  background: var(--secondary);
  border-radius: var(--background-color);
  padding: 10px;
  box-sizing: border-box;
  width: 100%;
}

.group-card {
  text-align: left;
  color: initial;
}

.group-name {
  font-weight: bold;
}

.group-members {
  opacity: 0.7;
}
</style>
