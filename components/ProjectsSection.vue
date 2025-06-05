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
  <div>
    <h2 class="text-5xl w-7/8 mx-auto">Projects</h2>
    <div class="md:bg-neutral-800 w-8/8 mx-auto py-10 md:p-16">
      <div
        class="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-16 w-7/8 mx-auto"
      >
        <div v-for="project in projects" :key="project.name">
          <ProjectCard :project="project" />
        </div>
      </div>
    </div>
  </div>
</template>

<style scoped lang="scss">
/* .horizontal {
  overflow-x: auto;
  overflow-y: hidden;
  white-space: nowrap;
  display: flex;
  flex-direction: row;
} */
</style>
