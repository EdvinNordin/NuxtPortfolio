<script setup>
defineProps({
  project: {
    type: Object,
    default: () => ({}),
  },
});

function formatName(name) {
  return name.replaceAll("_", " ");
}
</script>

<template>
  <div>
    <NuxtLink class="" :to="`/${project.name}`">
      <div class="flex flex-col h-full border-1-black card bg-neutral-900">
        <img :src="project.image" :alt="project.name" class="projectImage" />

        <h2
          class="projectName text-2xl font-bold text-center mt-2 mb-2 text-lime-100"
        >
          {{ formatName(project.name) }}
        </h2>
      </div>
    </NuxtLink>
  </div>
</template>

<style lang="scss">
.card {
  /* width: 300px;*/
  height: 300px;
  overflow: hidden;
}
.card:hover {
  //background: #d3d3d3;
}

a:hover {
  background: none;
}

.projectImage {
  width: 100%;
  height: 100%;
  object-fit: cover;
}
</style>
