<script setup>
const backendUrl = import.meta.env.VITE_BACKEND_URL;
const route = useRoute();
const projectName = route.params.project;

const scrollForward = ref(true);
let scrollAnimation = null;
let autoScrollTimeout = false;

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

      if (
        container.scrollLeft + container.clientWidth >= container.scrollWidth ){
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
    cancelAnimationFrame(scrollAnimation);
    scrollAnimation = null;
});

const {data, error} = await useAsyncData("projects", () =>
  $fetch(backendUrl + '/projects')
  
);

</script>

<template>
  <h2 class="text-3xl">Other Projects</h2>
  <div class="horizontal" @mouseover="hovering" @mouseleave="stopHovering">
    <div v-for="project in data" :key="project.name" class="">
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
