<script setup>
const projects = ref([]);
const scrollForward = ref(true);
let scrollInterval = null;

function startAutoScroll() {
  nextTick(() => {
    // Only auto-scroll if not on mobile
    if (window.innerWidth < 769) return;
    const container = document.querySelector(".horizontal");
    if (!container) return;
    scrollInterval = setInterval(() => {
      if (scrollForward.value) {
        container.scrollBy({ left: 10, behavior: "smooth" });
      } else {
        container.scrollBy({ left: -10, behavior: "smooth" });
      }
      if (
        container.scrollLeft + container.clientWidth >=
        container.scrollWidth
      ) {
        scrollForward.value = false;
      }
      if (container.scrollLeft <= 0) {
        scrollForward.value = true;
      }
    }, 20); // Adjust speed by changing the interval
  });
}
function hovering() {
  clearInterval(scrollInterval);
}
function stopHovering() {
  scrollInterval = setTimeout(() => {
    startAutoScroll();
  }, 2000); // Adjust delay before resuming auto-scroll
}
onMounted(() => {
  fetch("/projects.json")
    .then((response) => response.json())
    .then((data) => {
      projects.value = data;
    })
    .catch((error) => {
      console.error("Error loading the JSON file:", error);
    });
  startAutoScroll();
});

onBeforeUnmount(() => {
  clearInterval(scrollInterval);
});
</script>

<template>
  <h2 class="title">Projects</h2>
  <div class="horizontal" @mouseover="hovering" @mouseleave="stopHovering">
    <div v-for="project in projects" :key="project.name">
      <ProjectCard :project="project" />
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
