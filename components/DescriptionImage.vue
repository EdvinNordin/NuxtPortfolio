<script setup>
const route = useRoute();
const projectName = route.params.project;
const project = ref(null);

onMounted(async () => {
  const response = await fetch("/projects.json");
  const data = await response.json();
  project.value = data.find((p) => p.name === projectName);
});
</script>

<template>
  <div>{{ project.name }}</div>
</template>
