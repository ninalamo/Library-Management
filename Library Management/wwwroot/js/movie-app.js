// Movie App JavaScript

// Global variables
let currentCarouselIndex = {};

// Initialize app when DOM is loaded
document.addEventListener('DOMContentLoaded', function() {
    initializeSearch();
    initializeCarousels();
    initializeModals();
});

// Search functionality
function initializeSearch() {
    const searchInput = document.getElementById('searchInput');
    const searchBtn = document.getElementById('searchBtn');
    
    if (searchInput && searchBtn) {
        // Search on button click
        searchBtn.addEventListener('click', function() {
            performSearch();
        });
        
        // Search on Enter key press
        searchInput.addEventListener('keypress', function(e) {
            if (e.key === 'Enter') {
                performSearch();
            }
        });
        
        // Auto-suggest on typing (debounced)
        let searchTimeout;
        searchInput.addEventListener('input', function() {
            clearTimeout(searchTimeout);
            searchTimeout = setTimeout(() => {
                if (this.value.length >= 3) {
                    showSearchSuggestions(this.value);
                } else {
                    hideSearchSuggestions();
                }
            }, 300);
        });
    }
}

function performSearch() {
    const searchInput = document.getElementById('searchInput');
    const searchTerm = searchInput.value.trim();
    
    if (searchTerm) {
        // Redirect to search results
        window.location.href = `/?searchTerm=${encodeURIComponent(searchTerm)}`;
    }
}

function showSearchSuggestions(searchTerm) {
    // Fetch search suggestions via AJAX
    fetch(`/Movie/Search?searchTerm=${encodeURIComponent(searchTerm)}`)
        .then(response => response.json())
        .then(data => {
            displaySearchSuggestions(data);
        })
        .catch(error => {
            console.error('Search error:', error);
        });
}

function displaySearchSuggestions(movies) {
    // Remove existing suggestions
    hideSearchSuggestions();
    
    if (movies.length === 0) return;
    
    const searchBar = document.querySelector('.search-bar');
    const suggestionsDiv = document.createElement('div');
    suggestionsDiv.className = 'search-suggestions';
    suggestionsDiv.innerHTML = `
        <div class="suggestions-list">
            ${movies.map(movie => `
                <div class="suggestion-item" onclick="goToMovie('${movie.id}')">
                    <img src="${movie.poster}" alt="${movie.title}" class="suggestion-poster">
                    <div class="suggestion-info">
                        <h6>${movie.title}</h6>
                        <span class="suggestion-meta">${movie.year} • ${movie.genre} • ★${movie.rating}</span>
                    </div>
                </div>
            `).join('')}
        </div>
    `;
    
    searchBar.appendChild(suggestionsDiv);
}

function hideSearchSuggestions() {
    const suggestions = document.querySelector('.search-suggestions');
    if (suggestions) {
        suggestions.remove();
    }
}

function goToMovie(movieId) {
    window.location.href = `/Movie/Details/${movieId}`;
}

// Carousel functionality
function initializeCarousels() {
    const carousels = document.querySelectorAll('.movie-carousel');
    
    carousels.forEach(carousel => {
        const carouselId = carousel.id;
        currentCarouselIndex[carouselId] = 0;
        
        // Add touch support for mobile
        addCarouselTouchSupport(carousel);
    });
}

function scrollCarousel(carouselId, direction) {
    const carousel = document.getElementById(carouselId);
    const slider = carousel.querySelector('.movie-slider');
    const cards = slider.querySelectorAll('.movie-card');
    const cardWidth = cards[0].offsetWidth + 8; // Including gap
    const visibleCards = Math.floor(slider.offsetWidth / cardWidth);
    const maxIndex = Math.max(0, cards.length - visibleCards);
    
    currentCarouselIndex[carouselId] = Math.max(0, Math.min(maxIndex, currentCarouselIndex[carouselId] + direction * visibleCards));
    
    const scrollAmount = currentCarouselIndex[carouselId] * cardWidth;
    slider.scrollTo({
        left: scrollAmount,
        behavior: 'smooth'
    });
}

function addCarouselTouchSupport(carousel) {
    const slider = carousel.querySelector('.movie-slider');
    let isDown = false;
    let startX;
    let scrollLeft;
    
    slider.addEventListener('mousedown', (e) => {
        isDown = true;
        slider.classList.add('active');
        startX = e.pageX - slider.offsetLeft;
        scrollLeft = slider.scrollLeft;
    });
    
    slider.addEventListener('mouseleave', () => {
        isDown = false;
        slider.classList.remove('active');
    });
    
    slider.addEventListener('mouseup', () => {
        isDown = false;
        slider.classList.remove('active');
    });
    
    slider.addEventListener('mousemove', (e) => {
        if (!isDown) return;
        e.preventDefault();
        const x = e.pageX - slider.offsetLeft;
        const walk = (x - startX) * 2;
        slider.scrollLeft = scrollLeft - walk;
    });
    
    // Touch events for mobile
    slider.addEventListener('touchstart', (e) => {
        startX = e.touches[0].pageX - slider.offsetLeft;
        scrollLeft = slider.scrollLeft;
    });
    
    slider.addEventListener('touchmove', (e) => {
        const x = e.touches[0].pageX - slider.offsetLeft;
        const walk = (x - startX) * 2;
        slider.scrollLeft = scrollLeft - walk;
    });
}

// Modal functionality
function initializeModals() {
    // Initialize Bootstrap modals if available
    if (typeof bootstrap !== 'undefined') {
        // Modal initialization handled by Bootstrap
    }
}

function showAddMovieModal() {
    fetch('/Movie/AddModal')
        .then(response => response.text())
        .then(html => {
            document.querySelector('#movieModal .modal-content').innerHTML = html;
            showModal('movieModal');
        })
        .catch(error => {
            console.error('Error loading add movie modal:', error);
            showAlert('Error loading modal', 'error');
        });
}

function showEditModal(movieId) {
    fetch(`/Movie/EditModal/${movieId}`)
        .then(response => response.text())
        .then(html => {
            document.querySelector('#movieModal .modal-content').innerHTML = html;
            showModal('movieModal');
        })
        .catch(error => {
            console.error('Error loading edit modal:', error);
            showAlert('Error loading modal', 'error');
        });
}

function showDeleteModal(movieId) {
    fetch(`/Movie/DeleteModal/${movieId}`)
        .then(response => response.text())
        .then(html => {
            document.querySelector('#movieModal .modal-content').innerHTML = html;
            showModal('movieModal');
        })
        .catch(error => {
            console.error('Error loading delete modal:', error);
            showAlert('Error loading modal', 'error');
        });
}

function showMovieInfo(movieId) {
    window.location.href = `/Movie/Details/${movieId}`;
}

function showModal(modalId) {
    if (typeof bootstrap !== 'undefined') {
        const modal = new bootstrap.Modal(document.getElementById(modalId));
        modal.show();
    } else {
        // Fallback for when Bootstrap is not available
        const modal = document.getElementById(modalId);
        modal.style.display = 'block';
        modal.classList.add('show');
        document.body.style.overflow = 'hidden';
    }
}

function hideModal(modalId) {
    if (typeof bootstrap !== 'undefined') {
        const modal = bootstrap.Modal.getInstance(document.getElementById(modalId));
        if (modal) modal.hide();
    } else {
        const modal = document.getElementById(modalId);
        modal.style.display = 'none';
        modal.classList.remove('show');
        document.body.style.overflow = 'auto';
    }
}

// Movie actions
function addToFavorites(movieId) {
    // This would typically save to user's favorites
    showAlert('Added to favorites!', 'success');
    
    // Add visual feedback
    const heartButtons = document.querySelectorAll(`[onclick="addToFavorites('${movieId}')"]`);
    heartButtons.forEach(button => {
        button.innerHTML = '<i class="fas fa-heart text-danger"></i>';
        button.onclick = () => removeFromFavorites(movieId);
    });
}

function removeFromFavorites(movieId) {
    showAlert('Removed from favorites!', 'info');
    
    // Add visual feedback
    const heartButtons = document.querySelectorAll(`[onclick*="${movieId}"]`);
    heartButtons.forEach(button => {
        if (button.innerHTML.includes('fa-heart')) {
            button.innerHTML = '<i class="fas fa-heart"></i>';
            button.onclick = () => addToFavorites(movieId);
        }
    });
}

// Form submissions
function submitMovieForm(formId, url) {
    const form = document.getElementById(formId);
    const formData = new FormData(form);
    
    fetch(url, {
        method: 'POST',
        body: formData
    })
    .then(response => {
        if (response.ok) {
            hideModal('movieModal');
            showAlert('Movie saved successfully!', 'success');
            setTimeout(() => {
                location.reload();
            }, 1500);
        } else {
            throw new Error('Failed to save movie');
        }
    })
    .catch(error => {
        console.error('Error:', error);
        showAlert('Error saving movie', 'error');
    });
}

function deleteMovie(movieId) {
    if (confirm('Are you sure you want to delete this movie?')) {
        fetch(`/Movie/Delete/${movieId}`, {
            method: 'DELETE'
        })
        .then(response => {
            if (response.ok) {
                hideModal('movieModal');
                showAlert('Movie deleted successfully!', 'success');
                setTimeout(() => {
                    location.reload();
                }, 1500);
            } else {
                throw new Error('Failed to delete movie');
            }
        })
        .catch(error => {
            console.error('Error:', error);
            showAlert('Error deleting movie', 'error');
        });
    }
}

// Rating functionality
function showRatingModal(movieId) {
    const modal = document.getElementById('ratingModal');
    if (modal) {
        document.getElementById('ratingMovieId').value = movieId;
        showModal('ratingModal');
        initializeStarRating();
    }
}

function initializeStarRating() {
    const stars = document.querySelectorAll('.star-rating i');
    const ratingInput = document.getElementById('ratingValue');
    
    stars.forEach((star, index) => {
        star.addEventListener('click', () => {
            const rating = index + 1;
            ratingInput.value = rating;
            
            // Update visual state
            stars.forEach((s, i) => {
                if (i < rating) {
                    s.classList.add('active');
                } else {
                    s.classList.remove('active');
                }
            });
        });
        
        star.addEventListener('mouseenter', () => {
            const rating = index + 1;
            
            stars.forEach((s, i) => {
                if (i < rating) {
                    s.style.color = '#ffd700';
                } else {
                    s.style.color = '#666';
                }
            });
        });
    });
    
    const starContainer = document.querySelector('.star-rating');
    if (starContainer) {
        starContainer.addEventListener('mouseleave', () => {
            const currentRating = parseInt(ratingInput.value) || 0;
            
            stars.forEach((s, i) => {
                if (i < currentRating) {
                    s.style.color = '#ffd700';
                    s.classList.add('active');
                } else {
                    s.style.color = '#666';
                    s.classList.remove('active');
                }
            });
        });
    }
}

function submitRating() {
    const form = document.getElementById('ratingForm');
    const formData = new FormData(form);
    const movieId = formData.get('MovieId') || document.getElementById('ratingMovieId').value;
    const userName = formData.get('UserName') || document.getElementById('ratingUserName').value;
    const ratingValue = formData.get('RatingValue') || document.getElementById('ratingValue').value;
    
    if (!userName || !ratingValue) {
        showAlert('Please fill in all fields', 'warning');
        return;
    }
    
    const data = {
        MovieId: movieId,
        UserName: userName,
        RatingValue: parseInt(ratingValue)
    };
    
    fetch('/Movie/Rate', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(data)
    })
    .then(response => response.json())
    .then(result => {
        if (result.success) {
            hideModal('ratingModal');
            showAlert('Rating submitted successfully!', 'success');
            
            // Update rating display if on details page
            const ratingDisplay = document.querySelector('.average-rating');
            if (ratingDisplay) {
                ratingDisplay.textContent = result.averageRating.toFixed(1);
            }
        } else {
            showAlert('Error submitting rating', 'error');
        }
    })
    .catch(error => {
        console.error('Error:', error);
        showAlert('Error submitting rating', 'error');
    });
}

// Comment functionality
function submitComment() {
    const movieId = document.getElementById('movieId').value;
    const userName = document.getElementById('userName').value;
    const commentText = document.getElementById('commentText').value;
    
    if (!userName || !commentText) {
        showAlert('Please fill in all fields', 'warning');
        return;
    }
    
    const data = {
        MovieId: movieId,
        UserName: userName,
        Text: commentText
    };
    
    fetch('/Movie/AddComment', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(data)
    })
    .then(response => response.json())
    .then(result => {
        if (result.success) {
            showAlert('Comment posted successfully!', 'success');
            document.getElementById('commentText').value = '';
            
            // Reload page to show new comment
            setTimeout(() => {
                location.reload();
            }, 1500);
        } else {
            showAlert('Error posting comment', 'error');
        }
    })
    .catch(error => {
        console.error('Error:', error);
        showAlert('Error posting comment', 'error');
    });
}

// Genre filtering
function filterByGenre(genre) {
    window.location.href = `/?genre=${encodeURIComponent(genre)}`;
}

// Utility functions
function showAlert(message, type = 'info') {
    // Create alert element
    const alert = document.createElement('div');
    alert.className = `alert alert-${type === 'error' ? 'danger' : type} alert-dismissible fade show movie-alert`;
    alert.style.cssText = `
        position: fixed;
        top: 20px;
        right: 20px;
        z-index: 9999;
        min-width: 300px;
        box-shadow: 0 4px 12px rgba(0,0,0,0.3);
    `;
    alert.innerHTML = `
        ${message}
        <button type="button" class="btn-close" data-bs-dismiss="alert"></button>
    `;
    
    document.body.appendChild(alert);
    
    // Auto-remove after 5 seconds
    setTimeout(() => {
        if (alert.parentNode) {
            alert.remove();
        }
    }, 5000);
    
    // Add click-to-dismiss functionality
    alert.querySelector('.btn-close').addEventListener('click', () => {
        alert.remove();
    });
}

function debounce(func, wait) {
    let timeout;
    return function executedFunction(...args) {
        const later = () => {
            clearTimeout(timeout);
            func(...args);
        };
        clearTimeout(timeout);
        timeout = setTimeout(later, wait);
    };
}

// Add CSS for search suggestions
const style = document.createElement('style');
style.textContent = `
    .search-suggestions {
        position: absolute;
        top: 100%;
        left: 0;
        right: 0;
        background-color: #222;
        border: 1px solid #444;
        border-radius: 8px;
        box-shadow: 0 4px 12px rgba(0,0,0,0.3);
        z-index: 1000;
        margin-top: 5px;
    }
    
    .suggestions-list {
        max-height: 400px;
        overflow-y: auto;
    }
    
    .suggestion-item {
        display: flex;
        align-items: center;
        padding: 12px;
        border-bottom: 1px solid #333;
        cursor: pointer;
        transition: background-color 0.2s ease;
    }
    
    .suggestion-item:hover {
        background-color: #333;
    }
    
    .suggestion-item:last-child {
        border-bottom: none;
    }
    
    .suggestion-poster {
        width: 40px;
        height: 60px;
        object-fit: cover;
        border-radius: 4px;
        margin-right: 12px;
    }
    
    .suggestion-info h6 {
        margin: 0 0 4px 0;
        color: white;
        font-size: 14px;
    }
    
    .suggestion-meta {
        font-size: 12px;
        color: #aaa;
    }
    
    .movie-alert {
        animation: slideInRight 0.3s ease;
    }
    
    @keyframes slideInRight {
        from {
            transform: translateX(100%);
            opacity: 0;
        }
        to {
            transform: translateX(0);
            opacity: 1;
        }
    }
`;
document.head.appendChild(style);
