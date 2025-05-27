<script setup>
defineProps({
  project: {
    type: Object,
    default: () => ({}),
  },
});

function formatName(name) {
  if (!name) return "";
  const newName = name.replaceAll("_", " ");
  return newName;
}
</script>

<template>
  <div v-if="project && project.name">
    <h1 class="title">
      {{ formatName(project.name) }}
    </h1>
    <img :src="project.image" :alt="project.name" class="image" />
    <p class="subtitle">{{ project.description }}</p>
  </div>
  <div v-else>
    <p>Project not found.</p>
  </div>
</template>

<style scoped lang="scss">
.image {
  max-width: 500px;
  margin-left: 20px;
}
</style>
