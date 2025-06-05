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
      <div
        class="flex flex-col h-[300px] overflow-hidden hover:border-2 border-green-400 background"
      >
        <img
          :src="project.image"
          :alt="project.name"
          class="object-cover h-full"
        />

        <h2 class="text-2xl font-bold text-center my-[10px]">
          {{ formatName(project.name) }}
        </h2>
      </div>
    </NuxtLink>
  </div>
</template>

<style lang="scss">
a:hover {
  background: none;
}
</style>
