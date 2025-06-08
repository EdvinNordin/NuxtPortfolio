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
    <HeaderSection />
    <InfoProject :project="project" class="mt-15" />
    <InfoCarousel :projectName="project?.name" />
  </div>
</template>
<style scoped lang="scss"></style>
