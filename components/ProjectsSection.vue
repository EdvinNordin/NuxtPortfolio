<script setup>
const projects = ref([]);
onMounted(() => {
  fetch("/projects.json")
    .then((response) => response.json())
    .then((data) => {
      projects.value = data;
    })
    .catch((error) => {
      console.error("Error loading the JSON file:", error);
    });
});
</script>
<template>
  <div class="pl-30">
    <h2 class="text-5xl">Projects</h2>
    <div class="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-5 ">
      <div v-for="project in projects" :key="project.name" class="mb-5">
        <ProjectCard :project="project" />
      </div>
    </div>
  </div>
</template>

<style scoped lang="scss">
.horizontal {
  overflow-x: auto;
  overflow-y: hidden;
  white-space: nowrap;
  display: flex;
  flex-direction: row;
}
</style>
