package utils

import (
	"encoding/base64"
	"encoding/hex"
	"fmt"
)

func HexToBase64(hexStr string) (string, error) {
	// Decode the hex string
	bytes, err := hex.DecodeString(hexStr)
	if err != nil {
		return "", fmt.Errorf("Error decoding hex: %v", err)
	}

	// Encode the bytes to base64
	base64Str := base64.StdEncoding.EncodeToString(bytes)

	return base64Str, nil
}
