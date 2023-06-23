public enum Gender {
    WOMAN(0),
    MAN(1);

    private final int value;

    Gender(int value) {
        this.value = value;
    }

    public int getValue() {
        return value;
    }
}