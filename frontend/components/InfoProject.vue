<script setup>

const backendUrl = import.meta.env.VITE_BACKEND_URL;
const route = useRoute();
const projectName = route.params.project;
let project = ref({});

useHead({
  title: formatName(projectName) + " - Edvin Nordin"
});

const { data, error } = await useAsyncData(
  () => route.params.project,
  () => $fetch(backendUrl + '/projects/' + route.params.project)
);

function formatName(name) {
  return name.replaceAll("_", " ");
}
</script>

<template>
  <div v-if="data && data.name" class="">
    <div class="flex flex-col w-7/8 md:w-3/4 mx-auto">
      <div>
        <h1 class="text-5xl primary font-bold">
          {{ formatName(data.name) }}
        </h1>
        <div class="md:flex md:flex-row md:w-full justify-between mt-5 gap-10">
          <p class="md:w-1/2 text-xl mb-10">{{ data.description }}</p>
          <iframe
            v-if="data.youtube"
            :src="data.youtube"
            frameborder="0"
            allowfullscreen
            class="md:w-1/2 w-full aspect-video"
          ></iframe>
          <a
            v-else-if="data.link"
            :href="data.link"
            target="_blank"
            class="md:w-1/2 w-full"
          >
            <img
              :src="data.image"
              :alt="data.name"
              class="w-full object-cover"
            />
          </a>
          <a
            v-else
            :href="data.document"
            target="_blank"
            class="md:w-1/2 w-full"
          >
            <img
              :src="data.image"
              :alt="data.name"
              class="w-full object-cover"
            />
          </a>
        </div>
        <div class="flex flex-row-reverse my-5">
          <a
            :href="data.github"
            target="_blank"
            class="text-green-100 hover:text-green-400 transition-colors"
          >
            <!-- Inline GitHub SVG icon -->
            <svg class="w-15 h-15" fill="currentColor" viewBox="0 0 24 24">
              <path
                d="M12 0C5.37 0 0 5.373 0 12c0 5.303 3.438 9.8 8.205 11.387.6.113.82-.258.82-.577
                0-.285-.01-1.04-.015-2.04-3.338.726-4.042-1.61-4.042-1.61-.546-1.387-1.333-1.756-1.333-1.756-1.09-.745.083-.729.083-.729
                1.205.085 1.84 1.237 1.84 1.237 1.07 1.834 2.807 1.304 3.492.997.108-.775.418-1.305.762-1.605-2.665-.304-5.466-1.334-5.466-5.931
                0-1.31.468-2.381 1.236-3.221-.124-.303-.535-1.523.117-3.176 0 0 1.008-.322 3.301 1.23a11.52 11.52 0 0 1 3.003-.404c1.018.005
                2.045.138 3.003.404 2.291-1.553 3.297-1.23 3.297-1.23.653 1.653.242 2.873.119 3.176.77.84 1.235 1.911 1.235 3.221
                0 4.609-2.803 5.625-5.475 5.921.43.371.823 1.102.823 2.222 0 1.606-.014 2.898-.014 3.293 0 .322.216.694.825.576C20.565
                21.796 24 17.299 24 12c0-6.627-5.373-12-12-12z"
              />
            </svg>
          </a>
        </div>
      </div>
    </div>
  </div>
</template>

<style scoped lang="scss"></style>
