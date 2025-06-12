<script setup>
defineProps({
  project: {
    type: Object,
    default: () => ({}),
  },
});

const { data, error } = await useAsyncData('weather', () =>
  $fetch('/weatherforecast')
);

function formatName(name) {
  return name.replaceAll("_", " ");
}
</script>

<template>
  <div class="py-5 mx-2">
    <h1>{{ data }}</h1>
    <NuxtLink :to="`/${project.name}`">
      <div class="flex flex-col w-full md:w-[250px] min-w-[250px] overflow-hidden greenBorder background">
        <img :src="project.image" :alt="project.name" class="object-cover h-[200px]" />
        <div class="text-center items-center h-[50px] justify-center flex">
          <h2 class="text-lg font-bold">
            {{ formatName(project.name) }}
          </h2>
        </div>
      </div>
    </NuxtLink>
  </div>
</template>

<style lang="scss" contained>
a:hover {
  background: none;
}

.greenBorder:hover {
  box-shadow: 0px 0px 0px 3px var(--color-green-400);
  color: var(--color-green-400);
}
</style>
