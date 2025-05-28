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
    <div class="flex flex-row w-full justify-center mb-30">
      <div class="flex flex-col items-start justify-between">
        <h1 class="title mb-10">
          {{ formatName(project.name) }}
        </h1>
        <div class="description">
          <p class="subtitle">{{ project.description }}</p>
        </div>
        <div class="w-1/5 text-center inline-block">
          <a :href="project.link" target="_blank">
            <div class="butt">Link</div>
          </a>
          <a :href="project.repo" target="_blank">
            <div class="butt">Github</div>
          </a>
        </div>
      </div>
      <img :src="project.image" :alt="project.name" class="image" />
    </div>
  </div>
</template>

<style scoped lang="scss">
.butt {
  background-color: grey;
  border-radius: 5px;
  padding: 10px;
}

.image {
  max-width: 700px;
  margin-left: 20px;
}

.description {
  max-width: 700px;
  margin-left: 20px;
}
</style>
