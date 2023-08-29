<script lang="ts">
export default {
    emits: ['pageName'],
    created() {
        // fetch("https://idsapi20230506235002.azurewebsites.net/api/Tasks")
        //     .then(response => response.json())
        //     .then(data => (this.totalVuePackages = data.total));
        this.$route.params.groupId;
        this.$emit('pageName', 'hello');
    }
};
</script>

<template>
    <div class="task">
        Task
    </div>
</template>

<style scoped></style>
