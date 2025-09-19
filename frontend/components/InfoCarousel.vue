<script setup lang="ts">
//const backendUrl = import.meta.env.VITE_BACKEND_URL;
const route = useRoute();
const projectName = route.params.project;

const scrollForward = ref(true);
let scrollAnimation: number | null = null;

function autoScroll() {
  // Only auto-scroll if not on mobile
  if (window.innerWidth < 769) return;

  const container = document.querySelector(".horizontal");
  if (!container) return;

  if (scrollForward.value) {
    container.scrollBy({ left: 2, behavior: "smooth" });
  } else {
    container.scrollBy({ left: -2, behavior: "smooth" });
  }

  if (container.scrollLeft + container.clientWidth >= container.scrollWidth) {
    scrollForward.value = false;
  }
  if (container.scrollLeft <= 0) {
    scrollForward.value = true;
  }

  scrollAnimation = requestAnimationFrame(autoScroll);
}

function hovering() {
  if (scrollAnimation) {
    cancelAnimationFrame(scrollAnimation);
    scrollAnimation = null;
  }
}
function stopHovering() {
  setTimeout(() => {
    autoScroll();
  }, 2000);
}

onMounted(() => {
  autoScroll();
});

onBeforeUnmount(() => {
  if (scrollAnimation) cancelAnimationFrame(scrollAnimation);
  scrollAnimation = null;
});

interface data {
  name: string;
  description: string;
  image: string;
  youtube?: string;
  link?: string;
  document?: string;
  github?: string;
}

/* const { data, error } = await useAsyncData<Project[]>("projects", () =>
  $fetch<Project[]>(backendUrl + '/projects')
); */

const projects = ref<data[]>([]);
onMounted(() => {
  fetch("/projects.json")
    .then((response) => response.json())
    .then((data) => {
      projects.value = data;
    })
    .catch((error) => {
      console.error("Error loading the JSON file:", error);
    });
});
</script>

<template>
  <h2 class="text-3xl">Other Projects</h2>
  <div class="horizontal" @mouseover="hovering" @mouseleave="stopHovering">
    <div v-for="project in projects" :key="project.name" class="">
      <InfoCard
        v-if="projectName !== project.name"
        :project="project"
        size="450"
      />
    </div>
  </div>
</template>

<style scoped lang="scss">
.horizontal {
  overflow-x: auto;
  overflow-y: hidden;
  white-space: nowrap;
  display: flex;
  flex-direction: row;
}
</style>
