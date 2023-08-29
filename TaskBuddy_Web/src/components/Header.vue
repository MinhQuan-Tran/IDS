<template>
  <div class="header">
    <router-link to="/home"><img class="avatar" src="../assets/profile-picture.jpg" alt="Home"></router-link>
    <span class="title">
      <slot>Header</slot>
    </span>
    <router-link to="/profile"><img class="avatar" src="../assets/profile-picture.jpg" alt="Avatar"></router-link>
  </div>
</template>

<style scoped>
.header {
  position: relative;
  left: -1px;
  right: -1px;
  width: auto;
  padding: 10px;
  height: 2em;
  display: flex;
  justify-content: space-between;
  align-items: center;
  font-size: xx-large;
  background: var(--secondary);
  box-shadow: 0 0 10px 0 rgba(0, 0, 0, 0.5);
}

.title {
  flex: 2;
  text-align: center;
}

.header:first-child,
.header:last-child {
  flex: 1;
  height: 1.15em;
}

.header:first-child>*,
.header:last-child>* {
  height: 100%;
}

.avatar {
  box-sizing: border-box;
  height: 100%;
  border: 2px solid var(--primary);
  border-radius: 50%;
  object-fit: cover;
}
</style>
