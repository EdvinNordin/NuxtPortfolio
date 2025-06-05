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
  <div v-if="project && project.name" class="">
    <div class="flex flex-col w-7/8 md:w-3/4 mx-auto">
      <div>
        <h1 class="text-5xl primary font-bold">
          {{ formatName(project.name) }}
        </h1>
        <div class="md:flex md:flex-row md:w-full justify-between mt-5 gap-10">
          <p class="md:w-1/2 text-xl mb-10">{{ project.description }}</p>
          <iframe
            v-if="project.youtube"
            :src="project.youtube"
            frameborder="0"
            allowfullscreen
            class="md:w-1/2 w-full aspect-video"
          ></iframe>
          <a
            v-else-if="project.link"
            :href="project.link"
            target="_blank"
            class="md:w-1/2 w-full"
          >
            <img
              :src="project.image"
              :alt="project.name"
              class="w-full object-cover"
            />
          </a>
          <a
            v-else
            :href="project.document"
            target="_blank"
            class="md:w-1/2 w-full"
          >
            <img
              :src="project.image"
              :alt="project.name"
              class="w-full object-cover"
            />
          </a>
        </div>
        <div class="flex flex-row-reverse my-5">
          <a :href="project.github" target="_blank" class="w-1/10 md:w-1/20">
            <img src="/github.png" alt="Github" />
          </a>
        </div>
      </div>
    </div>
  </div>
</template>

<style scoped lang="scss"></style>

<!-- link, youtube, document -->
