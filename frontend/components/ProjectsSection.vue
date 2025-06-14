<script setup>
/*const projects = ref([]);
onMounted(() => {
  fetch("/projects.json")
    .then((response) => response.json())
    .then((data) => {
      projects.value = data;
    })
    .catch((error) => {
      console.error("Error loading the JSON file:", error);
    });
});*/

const backendUrl = import.meta.env.VITE_BACKEND_URL;
const {data, error} = await useAsyncData("projects", () =>
  $fetch(backendUrl + '/projects')
  
);
</script>
<template>
  <div class="w-7/8 mx-auto md:w-full">
    <h2 class="text-5xl md:pl-5">Projects</h2>
    <div class="py-10 md:p-26 md:bg-neutral-800">
      <div
        class="grid gap-8 sm:grid-cols-1 md:grid-cols-2 lg:grid-cols-3 w-full max-w-7xl mx-auto md:px-4"
      >
        <div v-for="project in data" :key="project.name">
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
