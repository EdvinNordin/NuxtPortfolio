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
    <NuxtLink :to="`/${project.name}`">
      <div
        class="flex flex-col w-full md:w-[450px] overflow-hidden greenBorder background"
      >
        <img
          :src="project.image"
          :alt="project.name"
          class="object-cover h-[300px]"
        />
        <div class="text-center items-center h-[50px] justify-center flex">
          <h2 class="text-lg font-bold">
            {{ formatName(project.name) }}
          </h2>
        </div>
      </div>
    </NuxtLink>
  </div>
</template>

<style lang="scss">
a:hover {
  background: none;
}
.greenBorder:hover {
  box-shadow: 0px 0px 0px 3px var(--color-green-400);
}
</style>
