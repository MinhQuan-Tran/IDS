<script lang="ts">
export default {
  data() {
    return {
      formData: {
        email: '',
        password: '',
        // Add other form fields here
      }
    };
  },
  methods: {
    submitGoogleLogin(response: any) {
      console.log(response);

      fetch(`${import.meta.env.VITE_ROOT_API}/Account/GoogleLogin`, {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json'
        },
        body: JSON.stringify(response.credential)
      })
        .then(response => response.json())
        .then(data => {
          console.log(data);
        })
        .catch(error => {
          console.error(error);
        });
    },
    submitPasswordLogin(event: Event) {
      event.preventDefault();

      fetch(`${import.meta.env.VITE_ROOT_API}/Account/PasswordLogin`, {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json'
        },
        body: JSON.stringify({
          email: this.formData.email,
          password: this.formData.password
        })
      })
        .then(response => response.json())
        .then(data => {
          console.log(data);
        })
        .catch(error => {
          console.error(error);
        });
    },
  },
  mounted() {
    google.accounts.id.initialize({
      client_id: '855538175583-u7r1nr0afi8907ut4p30kbh7m0cmifeo.apps.googleusercontent.com',
      callback: this.submitGoogleLogin
    });

    const submitBtn = this.$refs.submit_btn as HTMLButtonElement;

    const googleBtn = document.getElementById('google_btn');
    google.accounts.id.renderButton(googleBtn, {
      theme: "outline",
      logo_alignment: "left",
      size: "large",
      width: submitBtn.offsetWidth + "px"
    });
  },
};
</script>

<template>
  <div class="login">
    <picture>
      <source srcset="/TaskBuddy_logo_dark.svg" media="(prefers-color-scheme: dark)" />
      <img src="/TaskBuddy_logo.svg" alt="TaskBuddy logo" height="300" width="300" />
    </picture>

    <form class="login-form" @submit="submitPasswordLogin">
      <div class="input-box">
        <input type="text" name="email" id="email" v-model="formData.email"
          pattern="[a-zA-Z0-9._%+\-]+@[a-zA-Z0-9.\-]+\.[a-zA-Z]{2,}$" placeholder="" required />
        <label for="email">Email</label>
      </div>
      <div class="input-box">
        <input type="password" name="password" id="password" v-model="formData.password" placeholder="" required />
        <label for="password">Password</label>
      </div>
      <button ref="submit_btn" type="submit" class="submit-button" data-status="normal">Login</button>
    </form>

    <div id="google_btn">
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
  align-items: center;
  width: 300px;
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

@media (prefers-color-scheme: dark) {}
</style>
