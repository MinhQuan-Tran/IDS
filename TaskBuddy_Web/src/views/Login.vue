<script lang="ts">
export default {
  methods: {
    test(response: any) {
      console.log(response)
    },
  },
  mounted() {
    let externalScript = document.createElement('script')
    externalScript.setAttribute('src', 'https://accounts.google.com/gsi/client')
    document.head.appendChild(externalScript)
  },
};
</script>

<template>
  <div class="login">
    <picture>
      <!-- <source srcset="/TaskBuddy_logo_dark.svg" media="(prefers-color-scheme: dark)" /> -->
      <img src="/TaskBuddy_logo.svg" alt="TaskBuddy logo" height="300" width="300" />
    </picture>

    <form action="" class="login-form">
      <div class="input-box">
        <input type="text" name="username" id="usename" required />
        <label for="username">Username</label>
      </div>
      <div class="input-box">
        <input type="password" name="password" id="password" required />
        <label for="password">Password</label>
      </div>
      <button type="submit">Login</button>
    </form>

    <div id="g_id_onload" data-client_id="855538175583-u7r1nr0afi8907ut4p30kbh7m0cmifeo.apps.googleusercontent.com"
      data-context="signin" data-ux_mode="popup" @data-callback="test" data-itp_support="true">
    </div>

    <div class="g_id_signin" data-type="standard" data-shape="rectangular" data-theme="outline" data-text="signin_with"
      data-size="large" data-logo_alignment="left">
    </div>

    <div class="signup">
      <p>New to TaskBuddy?</p>
      <router-link to="/signup">Sign up</router-link>
    </div>
  </div>
</template>

<style scoped>
.login {
  background: var(--background-color);
  box-sizing: border-box;
  width: 100%;
  align-self: stretch;
  display: flex;
  justify-content: space-evenly;
  align-items: center;
  flex-direction: column;
  padding: 2em;
}

picture {
  display: flex;
  justify-content: center;
}

.login-form {
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: flex-start;
  width: 300px;
}

.input-box {
  position: relative;
  width: 100%;
}

.input-box input {
  width: 100%;
  padding: 10px;
  box-sizing: border-box;
  border: none;
  border-bottom: 1px solid black;
  outline: none;
  margin-bottom: 1.5em;
}

.input-box label {
  position: absolute;
  top: 0;
  left: 0;
  padding: 10px;
  pointer-events: none;
  transition: all 0.3s ease-in-out;
}

.input-box input:focus~label,
.input-box input:valid~label {
  font-size: 0.8em;
  transform: translate(-10px, calc(-1 * (1em + 10px + 5px)));
  /* font size + padding + extra space */
}

.login-form button {
  width: 100%;
  padding: 10px;
  box-sizing: border-box;
  border: none;
  outline: none;
  font-weight: bold;
  cursor: pointer;
  margin-bottom: 1.5em;
  transition: all 0.3s ease-in-out;
}

.login-form button:hover {
  transform: translateY(-5px);
  box-shadow: 0 5px 10px rgba(0, 0, 0, 0.2);
}

.signup {
  display: flex;
  justify-content: center;
  align-items: center;
  flex-direction: column;
  font-size: large;
  text-align: center;
}

.signup p {
  margin-bottom: 0.2em;
}

@media (prefers-color-scheme: dark) {
  .input-box input {
    border-bottom: 1px solid white;
  }

  .input-box input:focus {
    border-bottom: 1px solid yellow;
  }

  .input-box input:focus~label,
  .input-box input:valid~label {
    color: var(--primary-color);
  }
}
</style>
