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
const {data, error} = await useAsyncData("projects", () =>
  $fetch('https://portfoliobackend-gvfwd3g0cpabghdx.swedencentral-01.azurewebsites.net/projects')
  
);
</script>
<template>
  <div class="w-7/8 mx-auto md:w-full">
    <h2 class="text-5xl pl-5">Projects</h2>
    <div class="py-10 md:p-26 md:bg-neutral-800">
      <div
        class="flex flex-col md:grid md:grid-cols-2 lg:grid-cols-3 xl:grid-cols-3 gap-16 md:w-7/8 mx-auto"
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
