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
    <div
      class="flex flex-row md:flex-row w-3/4 mx-auto justify-center align-center"
    >
      <div class="flex flex-col w-1/2">
        <h1 class="text-3xl text-lime-300">
          {{ formatName(project.name) }}
        </h1>
        <div class="">
          <p class="">{{ project.description }}</p>
        </div>
        <div class="w-full md:w-auto">
          <a :href="project.link" target="_blank">
            <div class="">Link</div>
          </a>
          <a :href="project.repo" target="_blank">
            <div class="">Github</div>
          </a>
        </div>
      </div>
      <img
        :src="project.image"
        :alt="project.name"
        class="w-1/2 object-contain"
      />
    </div>
  </div>
</template>

<style scoped lang="scss"></style>
