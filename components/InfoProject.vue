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
    <div class="flex flex-col md:flex-row w-7/8 md:w-3/4 mx-auto gap-10">
      <div class="flex flex-col md:w-1/2 justify-between">
        <div>
          <h1 class="text-5xl primary font-bold">
            {{ formatName(project.name) }}
          </h1>
          <div class="mt-5">
            <p class="">{{ project.description }}</p>
          </div>
        </div>
        <div class="flex flex-row-reverse md:flex-row">
          <a :href="project.github" target="_blank" class="w-1/10">
            <img src="/github.png" alt="Github" />
          </a>
        </div>
      </div>
      <iframe
        v-if="project.youtube"
        :src="project.youtube"
        frameborder="0"
        allowfullscreen
        class="md:w-1/2 aspect-video"
      ></iframe>
      <a
        v-else-if="project.link"
        :href="project.link"
        target="_blank"
        class="md:w-1/2"
      >
        <img
          :src="project.image"
          :alt="project.name"
          class="w-full object-cover"
        />
      </a>
      <a v-else :href="project.document" target="_blank" class="md:w-1/2">
        <img
          :src="project.image"
          :alt="project.name"
          class="w-full object-cover"
        />
      </a>
    </div>
  </div>
</template>

<style scoped lang="scss"></style>

<!-- link, youtube, document -->
