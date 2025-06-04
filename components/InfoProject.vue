<script setup>
defineProps({
  project: {
    type: Object,
    default: () => ({}),
  },
});

function formatName(name) {
  if (!name) return "";
}
</script>

<template>
  <div v-if="project && project.name" class="px-2">
    <div
      class="flex flex-row md:flex-row w-full justify-center items-start gap-6"
    >
      <div class="flex flex-col flex-1 items-start justify-between gap-4">
        <h1 class="title mb-2">
          {{ formatName(project.name) }}
        </h1>
        <div class="description">
          <p class="subtitle">{{ project.description }}</p>
        </div>
        <div class="w-full md:w-auto text-center flex gap-2">
          <a :href="project.link" target="_blank">
            <div class="butt">Link</div>
          </a>
          <a :href="project.repo" target="_blank">
            <div class="butt">Github</div>
          </a>
        </div>
      </div>
      <img
        :src="project.image"
        :alt="project.name"
        class="image w-full max-w-xs md:max-w-sm object-contain mx-auto md:mx-0"
      />
    </div>
  </div>
</template>

<style scoped lang="scss">
.image {
  border-radius: 8px;
}
.description {
  width: 100%;
}
.title {
  width: 100%;
}
</style>
