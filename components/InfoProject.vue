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
  <div v-if="project && project.name" class="h-[80vh]">
    <div class="flex flex-col md:flex-row w-7/8 md:w-3/4 mx-auto">
      <div class="flex flex-col md:w-1/2">
        <h1 class="text-3xl text-lime-300">
          {{ formatName(project.name) }}
        </h1>
        <div class="">
          <p class="">{{ project.description }}</p>
        </div>
      </div>
      <img
        :src="project.image"
        :alt="project.name"
        class="md:w-1/2 object-contain"
      />
      <div class="w-full flex flex-row justify-around">
        <a :href="project.link" target="_blank">
          <div class="">Link</div>
        </a>
        <a :href="project.repo" target="_blank">
          <div class="">Github</div>
        </a>
      </div>
    </div>
  </div>
</template>

<style scoped lang="scss"></style>
