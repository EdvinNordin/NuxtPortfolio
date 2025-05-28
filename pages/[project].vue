<script setup>
const route = useRoute();
const projectName = route.params.project;
const project = ref(null);

onMounted(async () => {
  try {
    const response = await fetch("/projects.json");
    const data = await response.json();
    project.value = data.find((p) => p.name === projectName);
  } catch (e) {
    project.value = null;
    console.log(e);
  }
});
</script>
<template>
  <div>
    <NuxtLink to="/">
      <h1 class="back">Back to Home</h1>
    </NuxtLink>
    <InfoProject :project="project" />
  </div>
</template>
<style scoped lang="scss">
.back {
  color: var(--primary-color);
  text-decoration: none;
  font-size: 1.2rem;
  margin-left: 1rem;
  margin-bottom: 1rem;
}
</style>
